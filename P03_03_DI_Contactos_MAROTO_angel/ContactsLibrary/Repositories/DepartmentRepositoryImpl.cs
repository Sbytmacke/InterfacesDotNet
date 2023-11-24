using Models;
namespace ContactsLibrary.Repositories;

public class DepartmentRepositoryImpl : IRepository<Department>
{
    private List<Department> listItems = new List<Department>();

    public Department AddItem(Department item)
    {
        listItems.Add(item);
        return item;
    }

    public Department? GetItem(string name)
    {
        foreach (Department department in listItems)
        {
            if (department.Name == name)
            {
                return department;
            }
        }
        return null;
    }

    public Boolean DeleteItem(string name)
    {
        foreach (Department department in listItems)
        {
            if (department.Name == name)
            {
                listItems.Remove(department);
                return true;
            }
        }
        return false;
    }

    public Department? UpdateItem(Department item)
    {
        foreach (Department department in listItems)
        {
            if (item.Name == department.Name)
            {
                department.Name = item.Name;
                department.ListEmployees = item.ListEmployees;
                return department;
            }
        }
        return null;
    }

    public List<Department> GetItems()
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
