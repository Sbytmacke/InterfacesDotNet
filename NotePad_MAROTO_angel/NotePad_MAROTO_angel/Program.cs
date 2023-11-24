using presenter;
using views;

namespace NotePad_MAROTO_angel;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize(); // Siempre debe cargar el primero
        NotePadView notePadView = new NotePadView();
        NotePadPresenter notePadPresenter = new NotePadPresenter(notePadView);
        Application.Run(notePadPresenter.init());
    }
}
