using System;

namespace models;
public class Employee
{
  public string DNI { get; }
  public string Name { get; set; }
  public string Email { get; set; }
  public string Phone { get; set; }
  public string Position { get; set; }
  public List<Department> ListDepartments { get; set; }  // Un empleado puede trabajar en varios departamentos

  public Employee(string dni, string name, string email, string phone, string position, List<Department> listDepartments)
  {
    DNI = dni;
    Name = name;
    Email = email;
    Phone = phone;
    Position = position;
    ListDepartments = listDepartments;
  }

  public override string ToString()
  {
    string departmentInfo = string.Join(", ", ListDepartments.Select(d => $"ID: {d.Id}, Name: {d.Name}"));
    return $"DNI: {DNI}, Name: {Name}, Email: {Email}, Phone: {Phone}, Position: {Position}, Departments: {departmentInfo}";
  }
}

