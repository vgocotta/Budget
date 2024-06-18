using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Budget.Infrastructure.Models;
/// <summary>
/// Representa a abstração da notificação de alteração de valor das propriedades
/// </summary>
public abstract class AbstractNotify : INotifyPropertyChanged
{
    /// <summary>
    /// Evento que notifica alteração de uma propriedade
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;
    /// <summary>
    /// Este método invoca o evento de notificação de alteração de propriedade
    /// </summary>
    /// <param name="propertyName"></param>
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null!) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    /// <summary>
    /// Este método realiza a alteração e a notificação da propriedade de forma genérica
    /// </summary>
    /// <typeparam name="T">Tipo da propriedade alterada</typeparam>
    /// <param name="field">Campo alterado</param>
    /// <param name="value">Novo valor do campo</param>
    /// <param name="propertyName">Nome da propriedade alterada</param>
    /// <returns></returns>
    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null!)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return true;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}
