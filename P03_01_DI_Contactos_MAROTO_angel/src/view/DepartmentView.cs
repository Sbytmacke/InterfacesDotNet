using models;
using controllers;
namespace view;

public class DepartmentView
{
  private IController<Department> departmentController;

  public DepartmentView(IController<Department> departmentController)
  {
    this.departmentController = departmentController;
  }
  public void ShowDepartmentMenu()
  {
    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
    while (true)
    {
      Console.WriteLine("\n");
      Console.WriteLine("======= Department CRUD Menu =======");
      Console.WriteLine("1. Add a new department");
      Console.WriteLine("2. Update a department");
      Console.WriteLine("3. Delete a department");
      Console.WriteLine("4. View a department");
      Console.WriteLine("5. List all departments");
      Console.WriteLine("6. Back to Main Menu");
      Console.Write("Enter your choice: ");
      Console.WriteLine("\n");

      if (int.TryParse(Console.ReadLine(), out int choice))
      {
        Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
        switch (choice)
        {
          case 1:
            var addResult = departmentController.AddItem();
            if (addResult.IsSuccess)
            {
              Console.WriteLine("Department added successfully.");
            }
            else
            {
              Console.WriteLine($"Failed to add department: {addResult.Error}");
            }
            break;
          case 2:
            var updateResult = departmentController.UpdateItem();
            if (updateResult.IsSuccess)
            {
              Console.WriteLine("Department updated successfully.");
            }
            else
            {
              Console.WriteLine($"Failed to update department: {updateResult.Error}");
            }
            break;
          case 3:
            var deleteResult = departmentController.DeleteItem();
            if (deleteResult.IsSuccess)
            {
              Console.WriteLine("Department deleted successfully.");
            }
            else
            {
              Console.WriteLine($"Failed to delete department: {deleteResult.Error}");
            }
            break;
          case 4:
            var viewResult = departmentController.GetItem();
            if (viewResult.IsSuccess)
            {
              Console.WriteLine($"Department Details: {viewResult.Value}");
            }
            else
            {
              Console.WriteLine($"Failed to view department: {viewResult.Error}");
            }
            break;
          case 5:
            var listResult = departmentController.GetItems();
            if (listResult.IsSuccess)
            {
              Console.WriteLine("List of Departments:");
              if (listResult.Value != null)
              {
                foreach (var department in listResult.Value)
                {
                  Console.WriteLine(department);
                }
              }
            }
            else
            {
              Console.WriteLine($"Failed to list departments: {listResult.Error}");
            }
            break;
          case 6:
            return;
          default:
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
            Console.WriteLine("Invalid choice. Please try again.");
            break;
        }
      }
      else
      {
        Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
        Console.WriteLine("Invalid input. Please enter a valid number.");
      }
    }
  }
}