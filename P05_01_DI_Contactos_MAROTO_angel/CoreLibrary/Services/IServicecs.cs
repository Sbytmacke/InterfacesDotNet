using System.Collections.Generic;

namespace CoreLibrary.Services;
public interface IDataService<T>
{
    void AddItem(T item);
    void UpdateItem(T item);
    void DeleteItem(string id);
    T GetItem(string id);
    ICollection<T> GetItems();
}
