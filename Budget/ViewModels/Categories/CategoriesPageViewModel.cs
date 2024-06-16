using Budget.Infrastructure.Data;
using Budget.Infrastructure.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;

namespace Budget.ViewModels.Categories;

public partial class CategoriesPageViewModel : ObservableObject
{
    [ObservableProperty]
    private ICollection<Category> categories = [];

    [ObservableProperty]
    private Category? _category = null;

    [ObservableProperty]
    private string newCategoryName = null!;

    private readonly BudgetContext _context;
    /// <summary>
    /// Construtor da classe de ViewModel para a CategoriesPage
    /// </summary>
    /// <param name="context"></param>
    public CategoriesPageViewModel(BudgetContext context)
    {
        _context = context;
    }

    [RelayCommand]
    private async Task LoadedPage()
    {
        await _context.Categories.LoadAsync();
        Categories = _context.Categories.Local.ToObservableCollection();
    }

    [RelayCommand]
    private void AddNew()
    {
        if (string.IsNullOrWhiteSpace(NewCategoryName))
        {
            return;
        }

        Category newCategory = new()
        {
            Name = NewCategoryName
        };

        Categories.Add(newCategory);
    }

    [RelayCommand]
    private async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }

    [RelayCommand]
    private void Delete()
    {
        if (Category == null)
        {
            return;
        }
        Categories.Remove(Category);
    }
}
