using models;
using repositories;
using utils;
namespace controllers;

public class EmployeeControllerImpl(IRepository<Employee> employeeRepository, IRepository<Department> departmentRepository) : IController<Employee>
{
  public Result<Employee> AddItem()
  {
    Console.WriteLine("Enter DNI (e.g., 12345678A):");
    string? dni = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(dni) || dni.Length != 9 || !dni.Substring(0, 8).All(char.IsDigit) || !char.IsLetter(dni[8]))
    {
      Console.WriteLine("Invalid DNI format. Please enter 8 digits followed by 1 letter.");
      return Result<Employee>.Failure("Invalid DNI format");
    }

    Console.WriteLine("Enter name (letters only, e.g., John):");
    string? name = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(name) || !name.All(char.IsLetter))
    {
      Console.WriteLine("Invalid name format. Please enter letters only.");
      return Result<Employee>.Failure("Invalid name format");
    }

    Console.WriteLine("Enter email (e.g., chivi7410@example.com):");
    string? email = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
    {
      Console.WriteLine("Invalid email format. Please enter a valid email address.");
      return Result<Employee>.Failure("Invalid email format");
    }

    Console.WriteLine("Enter phone (numbers only, e.g., 665808230):"); string? phone = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(phone) || !phone.All(char.IsDigit) || phone.Length != 9)
    {
      Console.WriteLine("Invalid phone format. Please enter numbers only.");
      return Result<Employee>.Failure("Invalid phone format");
    }

    Console.WriteLine("Enter your position (letters only):");
    string? position = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(position) || !position.All(char.IsLetter))
    {
      Console.WriteLine("Invalid position format. Please enter letters only.");
      return Result<Employee>.Failure("Invalid position format");
    }

    Console.WriteLine("Enter departments (separated by comma):");
    string? departmentsInput = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(departmentsInput))
    {
      Console.WriteLine("Departments cannot be empty.");
      return Result<Employee>.Failure("Departments cannot be empty");
    }

    // Separar los departamentos por coma y realizar el procesamiento para agregar el empleado
    string[] departmentNames = departmentsInput.Split(',').Select(d => d.Trim()).ToArray();
    List<Department> departmentsToSetEmployee = new List<Department>();
    Employee newEmployee = new Employee(dni.ToUpper(), name.ToUpper(), email.ToUpper(), phone, position.ToUpper(), departmentsToSetEmployee);

    foreach (string departmentName in departmentNames)
    {
      Department? department = departmentRepository.GetItem(departmentName.ToUpper());
      if (department == null)
      {
        Console.WriteLine($"Department: '{departmentName}' not exists.");
        return Result<Employee>.Failure($"Department: '{departmentName.ToUpper()}' not exists.");
      }
      departmentsToSetEmployee.Add(department);

      // Agregar este empleado al repositorio de departamentos
      department.ListEmployees.Add(newEmployee);
      departmentRepository.UpdateItem(department);
    }

    employeeRepository.AddItem(newEmployee);

    return Result<Employee>.Success(newEmployee);
  }

  public Result<Employee> DeleteItem()
  {
    Console.WriteLine("Enter the DNI of the employee you want to delete:");
    string? dni = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(dni))
    {
      return Result<Employee>.Failure("DNI cannot be empty");
    }

    var employeeToRemove = employeeRepository.GetItem(dni.ToUpper());

    if (employeeToRemove == null)
    {
      return Result<Employee>.Failure("Employee not found");
    }

    if (employeeRepository.DeleteItem(employeeToRemove.DNI.ToUpper()))
    {
      employeeRepository.DeleteItem(employeeToRemove.DNI.ToUpper());
      return Result<Employee>.Success(employeeToRemove);
    }
    else
    {
      return Result<Employee>.Failure("Failed to delete employee");
    }
  }

  public Result<Employee> GetItem()
  {
    Console.WriteLine("Enter the DNI of the employee you want to view:");
    string? dni = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(dni))
    {
      return Result<Employee>.Failure("DNI cannot be empty");
    }

    var employee = employeeRepository.GetItem(dni.ToUpper());

    if (employee != null)
    {
      return Result<Employee>.Success(employee);
    }
    else
    {
      return Result<Employee>.Failure("Employee not found");
    }
  }

  public Result<Employee> UpdateItem()
  {
    Console.WriteLine("Enter the DNI of the employee you want to update (e.g., 12345678A) (or press Enter to keep existing):");
    string? dni = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(dni) || dni.Length != 9 || !dni.Substring(0, 8).All(char.IsDigit) || !char.IsLetter(dni[8]))
    {
      Console.WriteLine("Invalid DNI format. Please enter 9 digits followed by 1 letter.");
      return Result<Employee>.Failure("Invalid DNI format");
    }

    var existingEmployee = employeeRepository.GetItem(dni.ToUpper());

    if (existingEmployee == null)
    {
      Console.WriteLine("Employee not found.");
      return Result<Employee>.Failure("Employee not found");
    }

    Console.WriteLine("Enter new name (letters only, e.g., John) (or press Enter to keep existing):"); string? name = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(name))
    {
      if (!name.All(char.IsLetter))
      {
        Console.WriteLine("Invalid name format. Please enter letters only.");
        return Result<Employee>.Failure("Invalid name format");
      }
      existingEmployee.Name = name.ToUpper();
    }

    Console.WriteLine("Enter new email (e.g., chivi7410@example.com):"); string? email = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(email))
    {
      if (!IsValidEmail(email))
      {
        Console.WriteLine("Invalid email format. Please enter a valid email address.");
        return Result<Employee>.Failure("Invalid email format");
      }
      existingEmployee.Email = email.ToUpper();
    }

    Console.WriteLine("Enter new phone (numbers only, e.g., 665808230) (or press Enter to keep existing):"); string? phone = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(phone))
    {
      if (!phone.All(char.IsDigit) || phone.Length != 9)
      {
        Console.WriteLine("Invalid phone format. Please enter numbers only.");
        return Result<Employee>.Failure("Invalid phone format");
      }
      existingEmployee.Phone = phone;
    }

    Console.WriteLine("New position (or press Enter to keep existing):");
    string? position = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(position))
    {
      if (!position.All(char.IsLetter))
      {
        Console.WriteLine("Invalid position format. Please enter letters only.");
        return Result<Employee>.Failure("Invalid position format");
      }
      existingEmployee.Position = position.ToUpper();
    }

    Console.WriteLine("New departments (separated by comma) (or press Enter to keep existing):");
    string? departmentsInput = Console.ReadLine();

    if (!string.IsNullOrWhiteSpace(departmentsInput))
    {
      // Separar los departamentos por coma y realizar el procesamiento para actualizar el empleado
      string[] departmentNames = departmentsInput.Split(',').Select(d => d.Trim()).ToArray();
      List<Department> departmentsToSetEmployee = new List<Department>();

      foreach (string departmentName in departmentNames)
      {
        Department? department = departmentRepository.GetItem(departmentName.ToUpper());
        if (department == null)
        {
          Console.WriteLine($"Department: '{departmentName.ToUpper()}' not exists.");
          return Result<Employee>.Failure($"Department: '{departmentName.ToUpper()}' not exists.");
        }
        departmentsToSetEmployee.Add(department);
      }

      existingEmployee.ListDepartments = departmentsToSetEmployee;
    }

    employeeRepository.UpdateItem(existingEmployee);

    return Result<Employee>.Success(existingEmployee);
  }
  public Result<List<Employee>> GetItems()
  {

    if (employeeRepository.GetItems().Count > 0)
    {

      return Result<List<Employee>>.Success(employeeRepository.GetItems());
    }
    else
    {
      return Result<List<Employee>>.Failure("List empty");
    }
  }

  private bool IsValidEmail(string email)
  {
    try
    {
      var addr = new System.Net.Mail.MailAddress(email);
      return addr.Address == email;
    }
    catch
    {
      return false;
    }
  }

}
