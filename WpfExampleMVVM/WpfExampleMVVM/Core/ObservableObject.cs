using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfExampleMVVM.Core;

internal class ObservableObject : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    /* Si la propiedad llama a este método, se invoca el evento PropertyChanged con el nombre 
    de la propiedad directamente/automáticamente, pero hay implementaciones que no lo tienen */
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
