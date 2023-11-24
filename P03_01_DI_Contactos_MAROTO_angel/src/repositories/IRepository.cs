namespace repositories;
public interface IRepository<T>
{
  List<T> GetItems();
  T? GetItem(string id);
  T AddItem(T item);
  T? UpdateItem(T item);
  Boolean DeleteItem(string id);
}