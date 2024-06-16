using Budget.Views.Expenses;

namespace Budget;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("Expenses/ExpenseDetail", typeof(ExpenseDetailPage));

    }
}
