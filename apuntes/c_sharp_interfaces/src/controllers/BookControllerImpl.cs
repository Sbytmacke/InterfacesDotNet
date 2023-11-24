using models;
using repositories;
namespace controllers;

public class BookControllerImpl(Repository<Book> bookRepository) : Controller<Book>
{
  public Book? AddItem()
  {
    Console.WriteLine("Enter Title:");
    string title = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(title))
    {
      Console.WriteLine("Title cannot be empty");
      return null;
    }

    Console.WriteLine("Enter Author:");
    string author = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(author))
    {
      Console.WriteLine("Author cannot be empty");
      return null;
    }

    Console.WriteLine("Enter Description:");
    string description = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(description))
    {
      Console.WriteLine("Description cannot be empty");
      return null;
    }

    Console.WriteLine("Enter Date Release (yyyy-MM-dd):");
    if (!DateOnly.TryParse(Console.ReadLine(), out DateOnly dateRelease))
    {
      Console.WriteLine("Invalid date format.");
      return null;
    }

    Book newBook = new Book(title, author, description, dateRelease);
    return bookRepository.AddItem(newBook);
  }

  public Book? DeleteItem()
  {
    // Un random para probar que funciona
    Guid guidRandom = Guid.NewGuid();

    Console.WriteLine("Enter the GUID of the book you want to delete:");
    if (!Guid.TryParse(Console.ReadLine(), out Guid bookId))
    {
      Console.WriteLine("Invalid GUID format.");
      return null;
    }

    var deletedBook = bookRepository.DeleteItem(bookId);
    if (deletedBook == null)
    {
      Console.WriteLine("Book not found.");
      return null;
    }

    Console.WriteLine($"Deleted book: {deletedBook}");

    return deletedBook;
  }

  public Book? GetItem()
  {
    Console.WriteLine("Enter the GUID of the book you want to view:");
    if (!Guid.TryParse(Console.ReadLine(), out Guid bookGuid))
    {
      Console.WriteLine("Invalid GUID format.");
      return null;
    }

    var book = bookRepository.GetItem(bookGuid);

    if (book != null)
    {
      Console.WriteLine($"Book Details:\n{book}");
    }
    else
    {
      Console.WriteLine("Book not found.");
    }

    return book;
  }


  public Book? UpdateItem()
  {
    {
      Console.WriteLine("Enter the GUID of the book you want to update:");
      if (!Guid.TryParse(Console.ReadLine(), out Guid bookGuid))
      {
        Console.WriteLine("Invalid GUID format.");
        return null;
      }

      var existingBook = bookRepository.GetItem(bookGuid);
      if (existingBook == null)
      {
        Console.WriteLine("Book not found.");
        return null;
      }

      Console.WriteLine("Enter new Author (or press Enter to keep existing):");
      string author = Console.ReadLine();
      Console.WriteLine("Enter new Description (or press Enter to keep existing):");
      string description = Console.ReadLine();
      Console.WriteLine("Enter new Date Release (yyyy-MM-dd) (or press Enter to keep existing):");
      string dateRelease = Console.ReadLine();
      dateRelease = string.IsNullOrEmpty(dateRelease) ? existingBook.DateRelease.ToString() : dateRelease;

      DateOnly releaseDate;
      if (DateOnly.TryParse(dateRelease, out releaseDate))
      {
        existingBook.Author = string.IsNullOrEmpty(author) ? existingBook.Author : author;
        existingBook.Description = string.IsNullOrEmpty(description) ? existingBook.Description : description;
        existingBook.DateRelease = releaseDate;
        bookRepository.UpdateItem(existingBook);
      }
      else
      {
        Console.WriteLine("Invalid date format.");
        return null;
      }

      return existingBook;
    }
  }


  public List<Book> GetItems()
  {
    Console.WriteLine("List of Books:");
    List<Book> listBooks = bookRepository.GetItems();
    if (listBooks.Count() > 0)
    {
      foreach (var book in listBooks)
      {
        Console.WriteLine(book.ToString());
      }
    }
    else
    {
      Console.WriteLine("List empty");
    }

    return listBooks;
  }
}


