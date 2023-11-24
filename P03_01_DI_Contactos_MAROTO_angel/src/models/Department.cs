using System;
using System.Collections.Generic;

namespace models;
public class Department
{
  private static int nextId = 1;
  public int Id { get; }
  public string Name { get; set; }
  public List<Employee> ListEmployees { get; set; }

  public Department(string name, List<Employee> listEmployees)
  {
    Id = GenerateNextId(); // Asigna el próximo ID    
    Name = name;
    ListEmployees = listEmployees;
  }

  private int GenerateNextId()
  {
    return nextId++;
  }

  public override string ToString()
  {
    string employeeInfo = string.Join(", ", ListEmployees.Select(e => e.ToString()));
    return $"Id: {Id}, Name: {Name}, Employees: {employeeInfo}";
  }
}
