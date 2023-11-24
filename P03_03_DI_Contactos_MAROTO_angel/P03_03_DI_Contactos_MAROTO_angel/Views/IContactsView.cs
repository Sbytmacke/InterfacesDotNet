namespace P03_03_DI_Contactos_MAROTO_angel.Views
{
    internal interface IContactsView
    {
        string CurrentFilePath { get; set; }

        event EventHandler NewFile;
        event EventHandler OpenFile;
        event EventHandler SaveFile;
        event EventHandler SaveAsFile;
    }
}
