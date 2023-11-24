using models;
namespace repositories;

public class EmployeeRepositoryImpl : IRepository<Employee>
{
  private List<Employee> listItems = new List<Employee>();

  public Employee AddItem(Employee item)
  {
    listItems.Add(item);
    return item;
  }

  public Employee? GetItem(string dni)
  {
    foreach (Employee Employee in listItems)
    {
      if (Employee.DNI == dni)
      {
        return Employee;
      }
    }
    return null;
  }

  public Boolean DeleteItem(string dni)
  {
    foreach (Employee Employee in listItems)
    {
      if (Employee.DNI == dni)
      {
        listItems.Remove(Employee);
        return true;
      }
    }
    return false;
  }

  public Employee? UpdateItem(Employee item)
  {
    foreach (Employee Employee in listItems)
    {
      if (item.DNI == Employee.DNI)
      {
        Employee.Name = item.Name;
        Employee.Email = item.Email;
        Employee.Phone = item.Phone;
        Employee.Position = item.Position;
        Employee.ListDepartments = item.ListDepartments;

        return Employee;
      }
    }

    return null;
  }

  public List<Employee> GetItems()
  {
    return listItems;
  }

}
