using WindowsFormSegundo.views.lastViews;

namespace WindowsFormSegundo.presenter;

internal class CounterPresenter
{
    private CounterView counterView;
    private DrawerView drawerView;

    public CounterPresenter(CounterView counterView, DrawerView drawerView)
    {
        this.counterView = counterView;
        this.drawerView = drawerView;

        counterView.ButtonPlus.Click += (_, _) => Sum();
        counterView.ButtonMinus.Click += (_, _) => Minus();
    }

    public Form getDraweView()
    {
        return drawerView;
    }

    public Form initCounterView()
    {
        return drawerView;
    }

    private void Minus()
    {
        int num = int.Parse(counterView.LabelCounter.Text);
        num--;
        counterView.LabelCounter.Text = num.ToString();
    }

    private void Sum()
    {
        int num = int.Parse(counterView.LabelCounter.Text);
        num++;
        counterView.LabelCounter.Text = num.ToString();
    }

    public Form getCounterView()
    {
        /*drawerView.ButtonCenter.Click += (_, _) =>
        {
            Application.Run(counterView);
        };*/
        return counterView;
    }
}
