using Budget.ViewModels.Categories;

namespace Budget.Views.Categories;

public partial class CategoriesPage : ContentPage
{
    public CategoriesPage(CategoriesPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}