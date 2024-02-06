using CommunityToolkit.Mvvm.ComponentModel;
using CoreLibrary.Models;
using CoreLibrary.Services;
using LiveCharts;
using LiveCharts.Wpf;
using System.Collections.ObjectModel;
using System.Linq;

namespace P05_01_DI_Contactos_MAROTO_angel.ViewModels;

public partial class ChartViewModel : ObservableObject
{
    private readonly IDataService<Employee> EmployeeService;

    public SeriesCollection PieSeries { get; set; }

    [ObservableProperty]
    private ObservableCollection<Employee> _employees;

    public ChartViewModel(IDataService<Employee> employeeService)
    {
        EmployeeService = employeeService;
        LoadData();
    }

    private void ConfigurePieSeries()
    {
        PieSeries = new SeriesCollection();

        var groupedEmployees = _employees.GroupBy(employee => employee.DepartmentName)
            .Select(group => new { Type = group.Key, Count = group.Count() });

        foreach (var group in groupedEmployees)
        {
            PieSeries.Add(new PieSeries
            {
                Title = group.Type,
                Values = new ChartValues<int> { group.Count }
            });
        }
    }

    public void LoadData()
    {
        _employees = new ObservableCollection<Employee>(EmployeeService.GetItems());
        ConfigurePieSeries();
    }
}
