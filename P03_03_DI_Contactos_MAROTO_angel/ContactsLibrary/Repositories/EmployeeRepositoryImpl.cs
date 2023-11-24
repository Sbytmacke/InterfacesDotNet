using Models;
namespace ContactsLibrary.Repositories;

public class EmployeeRepositoryImpl : IRepository<Employee>
{
    private List<Employee> listItems = new List<Employee>();

    public Employee? AddItem(Employee item)
    {
        if (GetItem(item.DNI) == null)
        {
            listItems.Add(item);
            return item;
        }
        return null;
    }

    public Employee? GetItem(string dni)
    {
        foreach (Employee employee in listItems)
        {
            if (employee.DNI == dni)
            {
                return employee;
            }
        }
        return null;
    }

    public Boolean DeleteItem(string dni)
    {
        foreach (Employee employee in listItems)
        {
            if (employee.DNI == dni)
            {
                listItems.Remove(employee);
                return true;
            }
        }
        return false;
    }

    public Employee? UpdateItem(Employee item)
    {
        foreach (Employee employee in listItems)
        {
            if (item.DNI == employee.DNI)
            {
                employee.Name = item.Name;
                employee.Email = item.Email;
                employee.Phone = item.Phone;
                employee.Position = item.Position;
                employee.FileImage = item.FileImage;

                return employee;
            }
        }

        return null;
    }

    public List<Employee> GetItems()
    {
        return listItems;
    }

    public void ClearItems()
    {
        if (listItems.Count > 0)
        {
            // Iteramos inversamente, ya que la posición de los elementos varía
            for (int i = listItems.Count - 1; i >= 0; i--)
            {
                listItems.RemoveAt(i);
            }
        }
    }
}
