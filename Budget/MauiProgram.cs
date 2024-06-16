using Budget.Infrastructure.Data;
using Budget.ViewModels.Categories;
using Budget.ViewModels.Expenses;
using Budget.ViewModels.Home;
using Budget.Views.Categories;
using Budget.Views.Expenses;
using Budget.Views.Home;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace Budget;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddDbContext<BudgetContext>();

        builder.Services.AddScoped<ExpensesPage>();
        builder.Services.AddScoped<ExpensesPageViewModel>();
        builder.Services.AddScoped<ExpenseDetailPage>();
        builder.Services.AddScoped<ExpenseDetailPageViewModel>();
        builder.Services.AddScoped<CategoriesPage>();
        builder.Services.AddScoped<CategoriesPageViewModel>();
        builder.Services.AddScoped<HomePage>();
        builder.Services.AddScoped<HomePageViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
