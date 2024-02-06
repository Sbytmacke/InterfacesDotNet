using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace P05_01_DI_Contactos_MAROTO_angel.Views;

public partial class SettingsView : UserControl
{
    public SettingsView()
    {
        InitializeComponent();
    }

    private void LanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (LanguageComboBox.SelectedItem is ComboBoxItem selectedItem)
        {
            string languageTag = selectedItem.Tag?.ToString();

            // Guardar la selección del idioma en la configuración de la aplicación
            Properties.Settings.Default.SelectedLanguage = languageTag;
            Properties.Settings.Default.Save();

            RestartApplication();
        }
    }

    private static void RestartApplication()
    {
        Process.Start(Process.GetCurrentProcess().MainModule.FileName);
        Application.Current.Shutdown();
    }
}
