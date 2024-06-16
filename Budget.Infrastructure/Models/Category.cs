namespace Budget.Infrastructure.Models;
/// <summary>
/// Representa a entidade de Categoria
/// </summary>
public class Category : AbstractNotify
{
    private int _id;
    private string _name = null!;

    public int Id
    {
        get => _id;
        private set
        {
            SetField(ref _id, value);
        }
    }
    public string Name
    {
        get => _name;
        set
        {
            SetField(ref _name, value);
        }
    }
}
