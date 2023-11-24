using System;
using controllers;
using models;

namespace view;

public class EmployeeView
{

  private IController<Employee> employeeController;

  public EmployeeView(IController<Employee> employeeController)
  {
    this.employeeController = employeeController;
  }

  public void ShowEmployeeMenu()
  {
    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");

    while (true)
    {
      Console.WriteLine("\n");
      Console.WriteLine("======= Employee CRUD Menu =======");
      Console.WriteLine("1. Add a new employee");
      Console.WriteLine("2. Update an employee");
      Console.WriteLine("3. Delete an employee");
      Console.WriteLine("4. View an employee");
      Console.WriteLine("5. List all employees");
      Console.WriteLine("6. Back to Main Menu");
      Console.Write("Enter your choice: ");
      Console.WriteLine("\n");

      if (int.TryParse(Console.ReadLine(), out int choice))
      {
        Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");

        switch (choice)
        {
          case 1:
            var addResult = employeeController.AddItem();
            if (addResult.IsSuccess)
            {
              Console.WriteLine("Employee added successfully.");
            }
            else
            {
              Console.WriteLine($"Failed to add employee: {addResult.Error}");
            }
            break;
          case 2:
            var updateResult = employeeController.UpdateItem();
            if (updateResult.IsSuccess)
            {
              Console.WriteLine("Employee updated successfully.");
            }
            else
            {
              Console.WriteLine($"Failed to update employee: {updateResult.Error}");
            }
            break;
          case 3:
            var deleteResult = employeeController.DeleteItem();
            if (deleteResult.IsSuccess)
            {
              Console.WriteLine("Employee deleted successfully.");
            }
            else
            {
              Console.WriteLine($"Failed to delete employee: {deleteResult.Error}");
            }
            break;
          case 4:
            var viewResult = employeeController.GetItem();
            if (viewResult.IsSuccess)
            {
              Console.WriteLine($"Employee Details: {viewResult.Value}");
            }
            else
            {
              Console.WriteLine($"Failed to view employee: {viewResult.Error}");
            }
            break;
          case 5:
            var listResult = employeeController.GetItems();
            if (listResult.IsSuccess)
            {
              Console.WriteLine("List of Employees:");
              if (listResult.Value != null)
              {
                foreach (var employee in listResult.Value)
                {
                  Console.WriteLine(employee);
                }
              }
            }
            else
            {
              Console.WriteLine($"Failed to list employees: {listResult.Error}");
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