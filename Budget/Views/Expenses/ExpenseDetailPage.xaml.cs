using Budget.ViewModels.Expenses;

namespace Budget.Views.Expenses;

public partial class ExpenseDetailPage : ContentPage
{
    public ExpenseDetailPage(ExpenseDetailPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}