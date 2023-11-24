namespace WindowsFormSegundo;
using views;
using WindowsFormSegundo.presenter;
using WindowsFormSegundo.views.lastViews;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize(); // Siempre debe cargar el primero
        PaintView paintView = new PaintView();
        DrawerView drawerView = new DrawerView();
        CounterView counterView = new CounterView();
        CounterPresenter counterController = new CounterPresenter(counterView, drawerView);
        FlappyBird flappyBird = new FlappyBird();


        NotePadView notePadView = new NotePadView();
        NotePadPresenter notePadPresenter = new NotePadPresenter(notePadView);
        Application.Run(notePadPresenter.init());
    }
}
