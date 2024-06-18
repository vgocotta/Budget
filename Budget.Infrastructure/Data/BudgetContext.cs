using Budget.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Budget.Infrastructure.Data;
/// <summary>
/// Esta classe representa o contexto do banco de dados 
/// </summary>
public class BudgetContext : DbContext
{
    /// <summary>
    /// Construdor da classe que executa a migração para a versão mais recente do banco de dados
    /// </summary>
    public BudgetContext()
    {
        Database.Migrate();
    }
    /// <summary>
    /// Representa a abstração da tabela Categorias do banco de dados
    /// </summary>
    public DbSet<Category> Categories { get; set; }
    /// <summary>
    /// Representa a abstração da tabelas Despesas do banco de dados
    /// </summary>
    public DbSet<Expense> Expenses { get; set; }
    /// <summary>
    /// Esta método é utilizado para configurar o banco de dados
    /// </summary>
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"Budget App");
        Directory.CreateDirectory(databasePath);

        optionsBuilder.UseSqlite($"Filename={Path.Combine(databasePath,"budget-test.db")}");
    }
}
