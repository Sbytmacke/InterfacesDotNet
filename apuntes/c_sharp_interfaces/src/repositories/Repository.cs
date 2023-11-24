namespace repositories;
public interface Repository<T>
{
  List<T> GetItems();
  T? GetItem(Guid guid);
  T AddItem(T item);
  T? UpdateItem(T item);
  T? DeleteItem(Guid guid);
}