using Maroto_Chivite_Angel_App_Sorteo.Presenters;

namespace Maroto_Chivite_Angel_App_Sorteo;
public partial class MainView : Form
{
    private MainPresenter mainPresenter;

    public MainView()
    {
        InitializeComponent();
        InitializeEventHandlers();
    }

    private void InitializeEventHandlers()
    {
        addName.Click += OnClickAddUser;
        addPrice.Click += OnClickAddPrice;
        randomWinner.Click += OnClickStartWinner;
        newPrice.Click += OnClickNewPrice;
    }

    private void OnClickAddUser(object? sender, EventArgs e)
    {
        string newName = textBoxUser.Text;
        if (!string.IsNullOrEmpty(newName))
        {
            mainPresenter.AddUser(newName);
        }
    }
    private void OnClickAddPrice(object? sender, EventArgs e)
    {
        string newPrice = textBoxPrice.Text;
        if (!string.IsNullOrEmpty(newPrice))
        {
            mainPresenter.AddPrice(newPrice);
        }
    }
    private void OnClickStartWinner(object? sender, EventArgs e)
    {
        mainPresenter.StartWinner();
    }
    private void OnClickNewPrice(object? sender, EventArgs e)
    {
        mainPresenter.NewPrice();
    }

    public void SetPresenter(MainPresenter presenter)
    {
        this.mainPresenter = presenter;
    }
}