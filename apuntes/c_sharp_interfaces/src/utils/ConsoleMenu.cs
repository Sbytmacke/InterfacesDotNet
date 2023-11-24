using models;
using controllers;
namespace utils;

public class ConsoleMenu(Controller<Book> bookController)
{
  public void Start()
  {
    while (true)
    {
      Console.WriteLine("======= Book CRUD Menu =======");
      Console.WriteLine("1. Add a new book");
      Console.WriteLine("2. Update a book");
      Console.WriteLine("3. Delete a book");
      Console.WriteLine("4. View a book");
      Console.WriteLine("5. List all books");
      Console.WriteLine("6. Exit");
      Console.Write("Enter your choice: ");


      if (int.TryParse(Console.ReadLine(), out int choice))
      {
        switch (choice)
        {
          case 1:
            WriteLine(50);
            bookController.AddItem();
            WriteLine(2);
            break;
          case 2:
            WriteLine(50);
            bookController.UpdateItem();
            WriteLine(2);
            break;
          case 3:
            WriteLine(50);
            bookController.DeleteItem();
            WriteLine(2);
            break;
          case 4:
            WriteLine(50);
            bookController.GetItem();
            WriteLine(2);
            break;
          case 5:
            WriteLine(50);
            bookController.GetItems();
            WriteLine(2);
            break;
          case 6:
            Environment.Exit(0);
            break;
          default:
            WriteLine(50);
            Console.WriteLine("Invalid choice. Please try again.");
            WriteLine(2);
            break;
        }
      }
      else
      {
        WriteLine(50);
        Console.WriteLine("Invalid input. Please enter a valid number.");
        WriteLine(2);
      }
    }
  }

  private static void WriteLine(int numLines)
  {
    for (int i = 0; i < numLines; i++)
    {
      Console.WriteLine();
    }
  }
}

