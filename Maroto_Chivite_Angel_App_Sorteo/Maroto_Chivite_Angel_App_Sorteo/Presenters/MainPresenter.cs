using Maroto_Chivite_Angel_App_Sorteo.Repositories;

namespace Maroto_Chivite_Angel_App_Sorteo.Presenters;

public class MainPresenter
{
    private MainView mainView;
    private UserRepository userRepository;
    private PriceRepository priceRepository;

    public MainPresenter(MainView mainView, UserRepository userRepo, PriceRepository priceRepo)
    {
        this.mainView = mainView;
        this.userRepository = userRepo;
        this.priceRepository = priceRepo;
    }

    internal void AddUser(string newName)
    {
        foreach (String name in userRepository.GetItems())
        {
            if (name.Equals(newName))
            {
                MessageBox.Show("Usuario ya existe", "Usuario ya existe", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
        }

        userRepository.AddItem(newName);

        mainView.dataGridUsers.Rows.Add(newName);
        int lastRowIndex = mainView.dataGridUsers.Rows.Count - 1;
        mainView.dataGridUsers.Rows[lastRowIndex].Tag = newName;

        MessageBox.Show("Añadido correctamente", "Añadido correctamente", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
    }

    internal void AddPrice(string newPrice)
    {
        foreach (String name in priceRepository.GetItems())
        {
            if (name.Equals(newPrice))
            {
                MessageBox.Show("Premio ya existe", "Premio ya existe", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
        }

        priceRepository.AddItem(newPrice);

        mainView.dataGridPrices.Rows.Add(newPrice);
        int lastRowIndex = mainView.dataGridPrices.Rows.Count - 1;
        mainView.dataGridPrices.Rows[lastRowIndex].Tag = newPrice;

        MessageBox.Show("Añadido correctamente", "Añadido correctamente", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
    }

    internal void NewPrice()
    {
        mainView.textBoxUser.Text = "";
        mainView.textBoxPrice.Text = "";
        mainView.dataGridUsers.Rows.Clear();
        mainView.dataGridPrices.Rows.Clear();

        userRepository.ClearItems();
        priceRepository.ClearItems();
    }

    internal void StartWinner()
    {
        List<String> listPrices = priceRepository.GetItems();
        List<String> listUsers = userRepository.GetItems();

        while (listPrices.Count != 0)
        {
            var random = new Random();
            int randomUser = random.Next(0, listPrices.Count - 1);
            int randomPrice = random.Next(0, listUsers.Count - 1);

            string userWinner = listUsers[randomUser];
            string priceWinner = listPrices[randomPrice];

            listUsers.RemoveAt(randomUser);
            listPrices.RemoveAt(randomPrice);

            MessageBox.Show("El usuario " + userWinner + " ha ganado " + priceWinner, "Ganador!", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }
    }

    internal Form InitView()
    {
        return mainView;
    }
}

