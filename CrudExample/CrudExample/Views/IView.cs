using System.Collections;

namespace CrudExample.Views
{
    interface IView<T>
    {
        void DisplayErrorMessage(string message);
        void AddItemToList(T item);
        void UpdateItemList(ArrayList items);
        void DeleteItem();
        int GetSelectedItemIndex();
    }
}
