using Budget.Infrastructure.Data;
using Budget.Infrastructure.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;

namespace Budget.ViewModels.Expenses;

public partial class ExpensesPageViewModel : ObservableObject
{

    [ObservableProperty]
    private ICollection<Expense> expenses = [];

    [ObservableProperty]
    private Expense? selectedExpense = null!;

    private readonly BudgetContext _context;
    public ExpensesPageViewModel(BudgetContext context)
    {
        _context = context;
    }

    private async Task DeleteSelected()
    {
        if (SelectedExpense == null)
        {
            return;
        }
        Expenses.Remove(SelectedExpense);
        await _context.SaveChangesAsync();
    }

    [RelayCommand]
    private async Task LoadedPage()
    {
        await _context.Expenses.Where(x => !x.HasEnded).LoadAsync();
        Expenses = _context.Expenses.Local.ToObservableCollection();
        SelectedExpense = null;
    }

    [RelayCommand]
    private async Task AddNew()
    {
        Dictionary<string, object> parameters = new()
            {
                { "expense", new Expense() {ExpenseDate = DateTime.Now } }
            };
        await Shell.Current.GoToAsync("ExpenseDetail", true, parameters);
    }

    [RelayCommand]
    private async Task OnSelectionChanged()
    {
        if (SelectedExpense == null)
        {
            return;
        }

        var result = await Application.Current!.MainPage!.DisplayActionSheet("O que deseja fazer?", null, null, FlowDirection.MatchParent, "Editar", "Excluir", "Cancelar");

        if (result == "Editar")
        {
            Dictionary<string, object> parameters = new()
            {
                { "expense", SelectedExpense }
            };
            await Shell.Current.GoToAsync("ExpenseDetail", true, parameters);
        }
        else if (result == "Excluir")
        {
            await DeleteSelected();
        }
        SelectedExpense = null;
    }
}
