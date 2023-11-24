using System;
namespace models;

public class Book
{
  public Guid Guid { get; }
  public string Title { get; set; }
  public string Author { get; set; }
  public string Description { get; set; }
  public DateOnly DateRelease { get; set; }

  public Book(string title, string author, string description, DateOnly dateRelease)
  {
    Guid = Guid.NewGuid();
    Title = title;
    Author = author;
    Description = description;
    DateRelease = dateRelease;
  }

  public override string ToString()
  {
    return $"Guid:{Guid}, Title: {Title}, Author: {Author}, Description: {Description}, DateRelease: {DateRelease}";
  }
}
