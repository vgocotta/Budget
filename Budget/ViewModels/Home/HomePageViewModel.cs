using Budget.Infrastructure.Data;
using Budget.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;

namespace Budget.ViewModels.Home;

public partial class HomePageViewModel : ObservableObject
{

    [ObservableProperty]
    private DateTime? _selectedDate;

    [ObservableProperty]
    private ICollection<BudgetValue> budgets = [];

    private readonly BudgetContext _context;
    public HomePageViewModel(BudgetContext context)
    {
        SelectedDate = DateTime.Now;
        _context = context;
    }

    public double? Total => Budgets?.Sum(x => x.Valor);

    private async Task SetBudgetList()
    {
        if (SelectedDate == null)
        {
            Budgets = [];
            OnPropertyChanged(nameof(Total));
            return;
        }

        int year = SelectedDate.Value.Year;
        int month = SelectedDate.Value.Month;
        var days = DateTime.DaysInMonth(year, month);

        DateTime begin = new(year, month, 1);
        DateTime end = new(year, month, days);

        Budgets = await _context
                  .Expenses
                  .Where
                  (
                  x => !x.HasEnded
                  && x.ExpenseDate >= begin
                  && x.ExpenseDate <= end
                  )
                  .GroupBy
                  (
                  k => k.Category.Name
                  )
                  .Select
                  (
                  g => new BudgetValue
                  {
                      Categoria = g.Key,
                      Valor = g.Sum(s => s.InstallmentValue) ?? 0
                  }
                  )
                  .ToListAsync();

        OnPropertyChanged(nameof(Total));
    }

    [RelayCommand]
    private async Task LoadedPage()
    {
        await SetBudgetList();
    }

    [RelayCommand]
    private async Task OnSelectedDate()
    {
        await SetBudgetList();
    }
}
