using controllers;
using models;
using utils;
namespace repositories;

public class DepartmentControllerImpl(IRepository<Employee> employeeRepository, IRepository<Department> departmentRepository) : IController<Department>
{
  public Result<Department> AddItem()
  {
    Console.WriteLine("Enter name:");
    string? name = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(name))
    {
      return Result<Department>.Failure("Name cannot be empty");
    }

    Department newDepartment = new Department(name.ToUpper(), new List<Employee>()); // Lista de empleados vacía
    departmentRepository.AddItem(newDepartment);

    return Result<Department>.Success(newDepartment);
  }

  public Result<Department> DeleteItem()
  {
    Console.WriteLine("Enter name:");
    string? name = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(name))
    {
      return Result<Department>.Failure("Name cannot be empty");
    }

    var departmentToDelete = departmentRepository.GetItem(name.ToUpper());

    if (departmentToDelete == null)
    {
      return Result<Department>.Failure("Department not found");
    }

    if (departmentRepository.DeleteItem(name.ToUpper()))
    {
      // Borramos el departamento de los empleados que lo tenían
      var employees = employeeRepository.GetItems();

      foreach (var employee in employees)
      {
        if (employee.ListDepartments.Contains(departmentToDelete))
        {
          employee.ListDepartments.Remove(departmentToDelete);
          // Actualizamos al empleado con la eliminación del departamento
          employeeRepository.UpdateItem(employee);
        }
      }

      departmentRepository.DeleteItem(departmentToDelete.Name.ToUpper());
      return Result<Department>.Success(departmentToDelete);
    }
    else
    {
      return Result<Department>.Failure("Failed to delete department");
    }
  }

  public Result<Department> UpdateItem()
  {
    Console.WriteLine("Enter name of department to update:");
    string? name = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(name))
    {
      return Result<Department>.Failure("Name cannot be empty");
    }

    var existingDepartment = departmentRepository.GetItem(name.ToUpper());

    if (existingDepartment == null)
    {
      return Result<Department>.Failure("Department not found");
    }

    Console.WriteLine("New name (or press Enter to keep existing):");
    string? newName = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(newName))
    {
      return Result<Department>.Failure("New name cannot be empty");
    }


    // Actualizamos el nombre del departamento de todos los empleados
    var employees = employeeRepository.GetItems();

    foreach (var employee in employees)
    {
      if (employee.ListDepartments.Contains(existingDepartment))
      {
        employee.ListDepartments[employee.ListDepartments.IndexOf(existingDepartment)].Name = newName.ToUpper();
        employeeRepository.UpdateItem(employee);
      }
    }

    existingDepartment.Name = newName.ToUpper();

    departmentRepository.UpdateItem(existingDepartment);

    return Result<Department>.Success(existingDepartment);
  }

  public Result<List<Department>> GetItems()
  {
    List<Department> departments = departmentRepository.GetItems();

    if (departments.Count > 0)
    {
      return Result<List<Department>>.Success(departments);
    }
    else
    {
      return Result<List<Department>>.Failure("List empty");
    }
  }

  public Result<Department> GetItem()
  {
    Console.WriteLine("Enter name:");
    string? name = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(name))
    {
      return Result<Department>.Failure("Name cannot be empty");
    }

    var department = departmentRepository.GetItem(name.ToUpper());

    if (department != null)
    {
      return Result<Department>.Success(department);
    }
    else
    {
      return Result<Department>.Failure("Department not found");
    }
  }
}
