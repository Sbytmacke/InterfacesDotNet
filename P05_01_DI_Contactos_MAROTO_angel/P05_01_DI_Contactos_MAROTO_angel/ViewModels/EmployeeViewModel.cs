using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CoreLibrary.Models;
using CoreLibrary.Services;
using Microsoft.Win32;
using P05_01_DI_Contactos_MAROTO_angel.Validators;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;

namespace P05_01_DI_Contactos_MAROTO_angel.ViewModels;

public partial class EmployeeViewModel : ObservableObject
{
    private IDataService<Employee> EmployeesService { get; set; }
    private IDataService<Department> DepartmentService { get; set; }

    [ObservableProperty]
    private ObservableCollection<Employee> _employees;

    [ObservableProperty]
    private byte[] _image;

    [ObservableProperty]
    private string _name;

    [ObservableProperty]
    private string _position;

    [ObservableProperty]
    private string _departmentName;

    [ObservableProperty]
    private string _email;

    [ObservableProperty]
    private string _dni;

    [ObservableProperty]
    private string _phone;

    public EmployeeViewModel(IDataService<Employee> employeeService, IDataService<Department> departmentService)
    {
        EmployeesService = employeeService;
        DepartmentService = departmentService;

        LoadData();
    }

    [RelayCommand]
    public void SelectEmployee(Employee SelectedItem)
    {
        if (SelectedItem == null)
        {
            return;
        }
        Dni = SelectedItem.Dni;
        DepartmentName = SelectedItem.DepartmentName;
        Name = SelectedItem.Name;
        Email = SelectedItem.Email;
        Phone = SelectedItem.Phone;
        Position = SelectedItem.Position;
        if (SelectedItem.Image == null)
        {
            byte[] imageBytes = Resources.Images.ResourcesImages.user_default;

            Image = imageBytes;
        }
        else
        {
            Image = SelectedItem.Image;
        }
    }

    [RelayCommand]
    public void SelectImage()
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Todos los archivos|*.*";

        if (openFileDialog.ShowDialog() == true)
        {
            string selectedImagePath = openFileDialog.FileName;
            byte[] imageBytes = File.ReadAllBytes(selectedImagePath);
            Image = imageBytes;
        }
    }

    [RelayCommand]
    public void DeleteEmployee(string DniFromListView)
    {

        string askForDelete = Properties.Resources.AskForDelete;
        string confirmDelete = Properties.Resources.ConfirmDelete;

        MessageBoxResult result = MessageBox.Show(askForDelete, confirmDelete, MessageBoxButton.YesNo, MessageBoxImage.Question);

        if (result == MessageBoxResult.Yes)
        {
            EmployeesService.DeleteItem(DniFromListView);

            var employeeToRemove = _employees.FirstOrDefault(e => e.Dni == DniFromListView);
            if (employeeToRemove != null)
            {
                _employees.Remove(employeeToRemove);
            }
        }
    }

    [RelayCommand]
    public void CreateEmployee()
    {
        var validator = new EmployeeValidator(EmployeesService, DepartmentService);

        if (!validator.ValidateCreateEmployeeFields(Dni, DepartmentName.ToUpper(), Name, Email, Phone, Position))
        {
            return;
        }

        var newEmployee = new Employee(Dni, DepartmentName.ToUpper(), Name, Email, Phone, Position, Image);
        EmployeesService.AddItem(newEmployee);

        _employees.Add(newEmployee);
    }

    [RelayCommand]
    public void UpdateEmployee()
    {
        var validator = new EmployeeValidator(EmployeesService, DepartmentService);

        if (!validator.ValidateUpdateEmployeeFields(Dni, DepartmentName.ToUpper(), Name, Email, Phone, Position))
        {
            return;
        }

        var updatedEmployee = new Employee(Dni, DepartmentName.ToUpper(), Name, Email, Phone, Position, Image);
        EmployeesService.UpdateItem(updatedEmployee);

        var employeeToRemove = _employees.FirstOrDefault(e => e.Dni == Dni);
        if (employeeToRemove != null)
        {
            _employees.Remove(employeeToRemove);
            _employees.Add(updatedEmployee);
        }
        else
        {
            MessageBox.Show(Properties.Resources.CanNotUpdate + ".", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    [RelayCommand]
    public void ClearFields()
    {
        Image = null;
        Name = "";
        Position = "";
        DepartmentName = "";
        Email = "";
        Dni = "";
        Phone = "";
    }


    public void LoadData()
    {
        _employees = new ObservableCollection<Employee>(EmployeesService.GetItems());
    }
}
