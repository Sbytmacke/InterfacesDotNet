using CoreLibrary.Models;
using CoreLibrary.Services;
using System.Linq;
using System.Windows;

namespace P05_01_DI_Contactos_MAROTO_angel.Validators;

public class EmployeeValidator
{
    private readonly IDataService<Employee> _employeeService;
    private readonly IDataService<Department> _departmentService;

    public EmployeeValidator(IDataService<Employee> employeeService, IDataService<Department> departmentService)
    {
        _employeeService = employeeService;
        _departmentService = departmentService;
    }

    public bool ValidateUpdateEmployeeFields(string dni, string departmentName, string name, string email, string phone, string position)
    {
        return ValidateCommonEmployeeFields(dni, departmentName, name, email, phone, position);
    }

    public bool ValidateCreateEmployeeFields(string dni, string departmentName, string name, string email, string phone, string position)
    {
        var DniExists = _employeeService.GetItem(dni);
        if (DniExists != null)
        {
            MessageBox.Show(Properties.Resources.TheDNI + " " + dni + " " + Properties.Resources.AlreadyExists + ".", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        return ValidateCommonEmployeeFields(dni, departmentName, name, email, phone, position);
    }

    private bool ValidateCommonEmployeeFields(string dni, string departmentName, string name, string email, string phone, string position)
    {
        if (string.IsNullOrWhiteSpace(dni))
        {
            MessageBox.Show(Properties.Resources.DNICanNotBeEmpty + ".", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        var departmentExists = _departmentService.GetItems().FirstOrDefault(d => d.Name == departmentName.ToUpper());
        if (departmentExists == null)
        {
            MessageBox.Show(Properties.Resources.TheDepartment + " " + departmentName + " " + Properties.Resources.NotExists + ".", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        if (string.IsNullOrWhiteSpace(departmentName))
        {
            MessageBox.Show(Properties.Resources.DepartmentCanNotBeEmpty + ".", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            MessageBox.Show(Properties.Resources.NameCanNotBeEmpty + ".", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        if (string.IsNullOrWhiteSpace(email))
        {
            MessageBox.Show(Properties.Resources.EmailCanNotBeEmpty + ".", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        if (string.IsNullOrWhiteSpace(phone))
        {
            MessageBox.Show(Properties.Resources.PhoneCanNotBeEmpty + ".", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        if (string.IsNullOrWhiteSpace(position))
        {
            MessageBox.Show(Properties.Resources.PositionCanNotBeEmpty + ".", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        return true;
    }
}
