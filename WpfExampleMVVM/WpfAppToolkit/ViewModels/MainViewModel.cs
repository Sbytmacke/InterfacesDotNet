using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace WpfAppToolkit.ViewModels;

partial class MainViewModel : ObservableObject
{
    [NotifyPropertyChangedFor(nameof(ButtonText))] // Cuando queremos que cambie en otro lugar
    [ObservableProperty]
    private string? _name = "";

    public string ButtonText => $"Añadir: {Name}";

    [ObservableProperty]
    private ObservableCollection<string>? _names = new ObservableCollection<string>();

    [RelayCommand]
    public void StoreNames() => Names.Add(Name);
}
