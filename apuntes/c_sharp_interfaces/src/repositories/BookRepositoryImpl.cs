using models;
namespace repositories;

public class BookRepositoryImpl : Repository<Book>
{
  private List<Book> listItems = new List<Book>();

  public Book AddItem(Book item)
  {
    listItems.Add(item);
    return item;
  }

  public Book? GetItem(Guid guid)
  {
    foreach (Book book in listItems)
    {
      if (book.Guid == guid)
      {
        return book;
      }
    }
    return null;
  }

  public Book? DeleteItem(Guid guid)
  {
    foreach (Book book in listItems)
    {
      if (book.Guid == guid)
      {
        listItems.Remove(book);
        return book;
      }
    }
    return null;
  }

  public Book? UpdateItem(Book item)
  {
    foreach (Book book in listItems)
    {
      if (item.Guid == book.Guid)
      {
        book.Title = item.Title;
        book.Author = item.Author;
        book.Description = item.Description;
        return book;
      }
    }

    return null;
  }

  public List<Book> GetItems()
  {
    return listItems;
  }

}
