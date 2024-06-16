namespace Budget.Infrastructure.Models;
/// <summary>
/// Representa a entidade de Categoria
/// </summary>
public class Category : AbstractNotify
{
    private int _id;
    private string _name = null!;
    /// <summary>
    /// Código da categoria
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
    /// Nome da categoria
    /// </summary>
    public string Name
    {
        get => _name;
        set
        {
            SetField(ref _name, value);
        }
    }
}
