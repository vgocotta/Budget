using Budget.ViewModels.Expenses;

namespace Budget.Views.Expenses;

public partial class ExpensesPage : ContentPage
{
    public ExpensesPage(ExpensesPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}