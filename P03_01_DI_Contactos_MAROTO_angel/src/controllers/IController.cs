namespace controllers;
using utils;
public interface IController<T>
{
  Result<List<T>> GetItems();
  Result<T> GetItem();
  Result<T> AddItem();
  Result<T> UpdateItem();
  Result<T> DeleteItem();
}