using ContactsLibrary.Repositories;
using P03_03_DI_Contactos_MAROTO_angel.Presenters;

namespace P03_03_DI_Contactos_MAROTO_angel
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Fachada
            ContactsView contactsView = new ContactsView();

            EmployeeRepositoryImpl employeeRepositoryImpl = new EmployeeRepositoryImpl();
            DepartmentRepositoryImpl departmentRepositoryImpl = new DepartmentRepositoryImpl();
            ContactsPresenter contactsPresenter = new ContactsPresenter(contactsView, departmentRepositoryImpl, employeeRepositoryImpl);
            contactsPresenter.InitDataToTest(); // Datos de prueba, comentar esta línea si queremos iniciar vacía
            contactsPresenter.SetDepartmentsToTable();
            contactsView.SetPresenter(contactsPresenter);

            Application.Run(contactsPresenter.InitContactsView());
        }
    }
}