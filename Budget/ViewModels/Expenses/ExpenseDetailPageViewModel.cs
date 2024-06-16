using Budget.Infrastructure.Data;
using Budget.Infrastructure.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;

namespace Budget.ViewModels.Expenses;

[QueryProperty(nameof(Expense), "expense")]
public partial class ExpenseDetailPageViewModel : ObservableObject
{
    [ObservableProperty]
    private ICollection<Category> categories = [];

    [ObservableProperty]
    private Expense expense = null!;

    private readonly BudgetContext _context;
    /// <summary>
    /// Construtor da classe que representa o ViewModel para a ExpenseDetailPage
    /// </summary>
    /// <param name="context"></param>
    public ExpenseDetailPageViewModel(BudgetContext context)
    {
        _context = context;
    }

    [RelayCommand]
    private async Task LoadedPage()
    {
        Categories = await _context.Categories.ToListAsync();
    }

    [RelayCommand]
    private async Task SaveChanges()
    {
        if (Expense.Id == 0)
        {
            await _context.AddAsync(Expense);
        }
        await _context.SaveChangesAsync();
        await Shell.Current.GoToAsync("..");
    }

}
