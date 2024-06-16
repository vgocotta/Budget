using Budget.Infrastructure.Models;

namespace Budget.Models;
/// <summary>
/// Representa o orçamento apresentado
/// </summary>
public class BudgetValue : AbstractNotify
{
    private string _categoria = null!;
    private double _valor;
    /// <summary>
    /// Representa o nome da categoria
    /// </summary>
    public string Categoria { get => _categoria; set => SetField(ref _categoria, value); }
    /// <summary>
    /// Representa o valor total da categoria para o período informado
    /// </summary>
    public double Valor { get => _valor; set => SetField(ref _valor, value); }
}
