using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CoreLibrary.Models;
using CoreLibrary.Services;
using P05_01_DI_Contactos_MAROTO_angel.Validators;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace P05_01_DI_Contactos_MAROTO_angel.ViewModels;

public partial class DepartmentViewModel : ObservableObject
{
    private IDataService<Employee> EmployeesService { get; set; }

    private IDataService<Department> DepartmentService { get; set; }

    [ObservableProperty]
    private ObservableCollection<Department> _departments;

    [ObservableProperty]
    private string _name;

    public DepartmentViewModel(IDataService<Employee> employeeService, IDataService<Department> departmentService)
    {
        EmployeesService = employeeService;
        DepartmentService = departmentService;
        LoadData();
    }

    public void LoadData()
    {
        _departments = new ObservableCollection<Department>(DepartmentService.GetItems());
        // El departamento "NO-DEPARTMENT" es el único que no se podrá configurar,
        // ya que será el que se asigne por defecto a aquellos que no tengan un departamento asociado.
        _departments.Remove(_departments.FirstOrDefault(d => d.Name == "NO-DEPARTMENT"));
    }

    [RelayCommand]
    public void CreateDepartment()
    {
        var validator = new DepartmentValidator(DepartmentService);

        if (!validator.ValidateDepartmentFields(Name))
        {
            return;
        }

        var newDepartment = new Department(Name.ToUpper());
        DepartmentService.AddItem(newDepartment);

        _departments.Add(newDepartment);
    }

    [RelayCommand]
    public void DeleteDepartment(string NameDepartmentFromListView)
    {
        string askForDelete = Properties.Resources.AskForDeleteDepartment;
        string confirmDelete = Properties.Resources.ConfirmDelete;

        MessageBoxResult result = MessageBox.Show(askForDelete, confirmDelete, MessageBoxButton.YesNo, MessageBoxImage.Question);

        if (result == MessageBoxResult.Yes)
        {

            // Update a los empleados para dejar su departamento vacío y no genere conflicto al borrar el departamento
            foreach (var employee in EmployeesService.GetItems())
            {
                if (employee.DepartmentName == NameDepartmentFromListView.ToUpper())
                {
                    EmployeesService.UpdateItem
                        (
                            new Employee(employee.Dni, "NO-DEPARTMENT", employee.Name, employee.Email, employee.Phone, employee.Position, employee.Image)
                        );
                }
            }

            DepartmentService.DeleteItem(NameDepartmentFromListView);

            var departmentToRemove = _departments.FirstOrDefault(department => department.Name == NameDepartmentFromListView);
            if (departmentToRemove != null)
            {
                _departments.Remove(departmentToRemove);
            }
        }
    }

    [RelayCommand]
    public void SelectDepartment(Department SelectedItem)
    {
        if (SelectedItem == null)
        {
            return;
        }

        Name = SelectedItem.Name;
    }

    [RelayCommand]
    public void ClearFields()
    {
        Name = "";
    }
}
