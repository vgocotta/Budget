using Budget.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Budget.Infrastructure.Data;

public class BudgetContext : DbContext
{
    public BudgetContext()
    {
        Database.Migrate();
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Expense> Expenses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"Budget App");
        Directory.CreateDirectory(databasePath);

        optionsBuilder.UseSqlite($"Filename={Path.Combine(databasePath,"budget.db")}");
    }
}
