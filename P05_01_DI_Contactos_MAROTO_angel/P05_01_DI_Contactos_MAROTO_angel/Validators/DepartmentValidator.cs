using CoreLibrary.Models;
using CoreLibrary.Services;
using System.Linq;
using System.Windows;

namespace P05_01_DI_Contactos_MAROTO_angel.Validators;

public class DepartmentValidator
{
    private readonly IDataService<Department> _departmentService;

    public DepartmentValidator(IDataService<Department> departmentService)
    {
        _departmentService = departmentService;
    }

    public bool ValidateDepartmentFields(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            MessageBox.Show(Properties.Resources.DepartmentCanNotBeEmpty + ".", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        var departmentExists = _departmentService.GetItems().FirstOrDefault(d => d.Name == name.ToUpper());
        if (departmentExists != null)
        {
            MessageBox.Show(Properties.Resources.TheDepartment + " " + name.ToUpper() + " " + Properties.Resources.AlreadyExists + ".", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        return true;
    }
}
