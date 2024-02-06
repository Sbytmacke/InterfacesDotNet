using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace P05_01_DI_Contactos_MAROTO_angel.ViewModels;
public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableObject _currentViewModel;

    private HomeViewModel _homeViewModel;
    private EmployeeViewModel _employeeViewModel;
    private DepartmentViewModel _departmentViewModel;
    private ChartViewModel _chartViewModel;
    private SettingsViewModel _settingsViewModel;

    public MainViewModel(
        HomeViewModel homeViewModel,
        EmployeeViewModel employeeViewModel,
        DepartmentViewModel departmentViewModel,
        ChartViewModel chartViewModel,
        SettingsViewModel settingsViewModel
    )
    {
        // ViewModel inicial
        _currentViewModel = homeViewModel;

        _homeViewModel = homeViewModel;
        _employeeViewModel = employeeViewModel;
        _departmentViewModel = departmentViewModel;
        _chartViewModel = chartViewModel;
        _settingsViewModel = settingsViewModel;
    }

    [RelayCommand]
    public void ShowHome()
    {
        CurrentViewModel = _homeViewModel;
        if (CurrentViewModel is HomeViewModel homeViewModel)
        {
            homeViewModel.LoadData();
        }
    }

    [RelayCommand]
    public void ShowEmployees()
    {
        CurrentViewModel = _employeeViewModel;
        if (CurrentViewModel is EmployeeViewModel employeeViewModel)
        {
            employeeViewModel.LoadData();
        }
    }

    [RelayCommand]
    public void ShowDepartments()
    {
        CurrentViewModel = _departmentViewModel;
        if (CurrentViewModel is DepartmentViewModel departmentViewModel)
        {
            departmentViewModel.LoadData();
        }
    }

    [RelayCommand]
    public void ShowCharts()
    {
        CurrentViewModel = _chartViewModel;
        if (CurrentViewModel is ChartViewModel chartViewModel)
        {
            chartViewModel.LoadData();
        }
    }

    [RelayCommand]
    public void ShowSettings()
    {
        CurrentViewModel = _settingsViewModel;
    }

    [RelayCommand]
    public void LogOut()
    {
        Application.Current.Shutdown();
    }
}

