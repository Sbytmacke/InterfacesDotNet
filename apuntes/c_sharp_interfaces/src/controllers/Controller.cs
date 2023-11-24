namespace controllers;

using models;
using repositories;
public interface Controller<T>
{
  List<Book> GetItems();
  T? GetItem();
  T? AddItem();
  T? UpdateItem();
  T? DeleteItem();
}