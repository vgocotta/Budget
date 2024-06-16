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

    public int Id
    {
        get => _id;
        private set
        {
            SetField(ref _id, value);
        }
    }

    public string Description
    {
        get => _description;
        set
        {
            SetField(ref _description, value);
        }
    }
    public double ExpenseValue
    {
        get => _expenseValue;
        set
        {
            SetField(ref _expenseValue, value);
        }
    }
    public DateTime ExpenseDate
    {
        get => _expenseDate;
        set
        {
            SetField(ref _expenseDate, value);
        }
    }
    public bool HasEnded
    {
        get => _hasEnded;
        set
        {
            SetField(ref _hasEnded, value);
        }
    }
    public bool IsRecurrent
    {
        get => _isRecurrent;
        set
        {
            SetField(ref _isRecurrent, value);
        }
    }
    public int? Installments
    {
        get => _installments;
        set
        {
            SetField(ref _installments, value);
        }
    }
    public double? InstallmentValue
    {
        get => _installmentValue;
        set
        {
            SetField(ref _installmentValue, value);
        }
    }
    public double Balance
    {
        get => _balance;
        set
        {
            SetField(ref _balance, value);
        }
    }

    public int CategoryId
    {
        get => _categoryId;
        set
        {
            SetField(ref _categoryId, value);
        }
    }
    public virtual Category Category
    {
        get => _category;
        set
        {
            SetField(ref _category, value);
        }
    }
}
