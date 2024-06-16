namespace Budget.Infrastructure.Models;
/// <summary>
/// Representa a entidade de Despesa
/// </summary>
public class Expense : AbstractNotify
{
    private int _id;
    private string _description = null!;
    private double _expenseValue;
    private DateTime _expenseDate;
    private bool _hasEnded;
    private bool _isRecurrent;
    private int? _installments;
    private double? _installmentValue;
    private double _balance;
    private int _categoryId;
    private Category _category = null!;
    /// <summary>
    /// Código da despesa
    /// </summary>
    public int Id
    {
        get => _id;
        private set
        {
            SetField(ref _id, value);
        }
    }
    /// <summary>
    /// Descrição da despesa
    /// </summary>
    public string Description
    {
        get => _description;
        set
        {
            SetField(ref _description, value);
        }
    }
    /// <summary>
    /// Valor da despesa
    /// </summary>
    public double ExpenseValue
    {
        get => _expenseValue;
        set
        {
            SetField(ref _expenseValue, value);
        }
    }
    /// <summary>
    /// Data da despesa
    /// </summary>
    public DateTime ExpenseDate
    {
        get => _expenseDate;
        set
        {
            SetField(ref _expenseDate, value);
        }
    }
    /// <summary>
    /// Indicador de despesa finalizada
    /// </summary>
    public bool HasEnded
    {
        get => _hasEnded;
        set
        {
            SetField(ref _hasEnded, value);
        }
    }
    /// <summary>
    /// Indicador de despesa recorrente
    /// </summary>
    public bool IsRecurrent
    {
        get => _isRecurrent;
        set
        {
            SetField(ref _isRecurrent, value);
        }
    }
    /// <summary>
    /// Número de parcelas
    /// </summary>
    public int? Installments
    {
        get => _installments;
        set
        {
            SetField(ref _installments, value);
        }
    }
    /// <summary>
    /// Valor da parcela
    /// </summary>
    public double? InstallmentValue
    {
        get => _installmentValue;
        set
        {
            SetField(ref _installmentValue, value);
        }
    }
    /// <summary>
    /// Saldo devedor
    /// </summary>
    public double Balance
    {
        get => _balance;
        set
        {
            SetField(ref _balance, value);
        }
    }
    /// <summary>
    /// Código da categoria
    /// </summary>
    public int CategoryId
    {
        get => _categoryId;
        set
        {
            SetField(ref _categoryId, value);
        }
    }
    /// <summary>
    /// Esta propriedade representa o objeto do tipo Categoria que está relacionada à despesa
    /// </summary>
    public virtual Category Category
    {
        get => _category;
        set
        {
            SetField(ref _category, value);
        }
    }
}
