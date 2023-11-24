using models;
namespace repositories;

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
      if (item.Id == department.Id)
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

}
