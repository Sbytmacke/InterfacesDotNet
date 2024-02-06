using Maroto_Chivite_Angel_App_Sorteo.Presenters;
using Maroto_Chivite_Angel_App_Sorteo.Repositories;

namespace Maroto_Chivite_Angel_App_Sorteo
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

            MainView mainView = new MainView();
            UserRepository userRepo = new UserRepository();
            PriceRepository priceRepo = new PriceRepository();
            MainPresenter mainPresenter = new MainPresenter(mainView, userRepo, priceRepo);
            mainView.SetPresenter(mainPresenter);

            Application.Run(mainView);
        }
    }
}