namespace Maroto_Chivite_Angel_App_Sorteo.Repositories;

public class PriceRepository
{
    private List<String> listItems = new List<String>();

    public String AddItem(String item)
    {
        listItems.Add(item);
        return item;
    }

    public Boolean DeleteItem(string name)
    {
        foreach (String Name in listItems)
        {
            if (Name == name)
            {
                listItems.Remove(Name);
                return true;
            }
        }
        return false;
    }

    public List<String> GetItems()
    {
        return listItems;
    }

    public void ClearItems()
    {
        if (listItems.Count > 0)
        {
            // Iteramos inversamente, ya que la posici�n de los elementos var�a
            for (int i = listItems.Count - 1; i >= 0; i--)
            {
                listItems.RemoveAt(i);
            }
        }
    }
}

