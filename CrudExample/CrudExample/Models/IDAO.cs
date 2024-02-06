using System.Collections;

namespace CrudExample.Models
{
    interface IDAO<T>
    {
        void AddItem(T item);

        T GetItem(int index);

        void UpdateItem(int index, T item);

        void DeleteItem(int index);

        ArrayList GetData();
    }
}
