namespace CrudExample
{
    interface IPresenter<T>
    {
        void AddNewItem();

        void DeleteItem();

        void Update();

        void BrowseItem();

        void EditItem();

    }
}
