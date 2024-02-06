using System.Collections.ObjectModel;
using WpfExampleMVVM.Core;

namespace WpfExampleMVVM.ViewModels;

internal class MainViewModel : ObservableObject
{
    // Como implementamos ObservableObject, podemos hacer las propiedades observables

    // Tienen que esta inicializadas...
    private string? _name = "";

    private ObservableCollection<string>? _names = new ObservableCollection<string>(); // Esto son los MODELOS

    // Si queremos más reactividad, entonces en vez de colecion de empleados, debe ser una coleccion de EmpleadosVieModel

    // Una atributo para el string y otro para la coleccion de strings
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
            OnPropertyChanged((nameof(Name)));
        }
    }

    public ObservableCollection<string> Names
    {
        get
        {
            return _names;
        }
        set
        {
            _names = value;
            OnPropertyChanged((nameof(Names)));
        }
    }

    // Comandos perosnalizados, los ponemos público para suscribrulos desde la vista
    public RelayCommand StoreNamesCommand { get; set; }

    public MainViewModel()
    {
        // Creamos comandos
        StoreNamesCommand = new RelayCommand(o => StoreNames());
    }

    public void StoreNames()
    {
        Names.Add(Name);
        OnPropertyChanged(nameof(Names));
    }
}
