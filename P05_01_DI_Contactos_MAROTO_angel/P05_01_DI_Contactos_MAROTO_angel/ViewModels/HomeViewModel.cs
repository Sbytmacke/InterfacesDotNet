
using CommunityToolkit.Mvvm.ComponentModel;
using CoreLibrary.Models;
using CoreLibrary.Services;
using System.Collections.ObjectModel;

namespace P05_01_DI_Contactos_MAROTO_angel.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    private IDataService<Employee> EmployeeService { get; set; }


    [ObservableProperty]
    private ObservableCollection<Employee> _employees;

    [ObservableProperty]
    private ObservableCollection<Department> _departments;

    public HomeViewModel(IDataService<Employee> employeeService)
    {
        EmployeeService = employeeService;
        LoadData();
    }

    public void LoadData()
    {
        _employees = new ObservableCollection<Employee>(EmployeeService.GetItems());
    }
}
