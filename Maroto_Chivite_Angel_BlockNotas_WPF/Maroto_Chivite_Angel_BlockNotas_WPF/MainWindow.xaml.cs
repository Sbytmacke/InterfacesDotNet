using Microsoft.Win32;
using System.Windows;

namespace Maroto_Chivite_Angel_BlockNotas_WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnClickOpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            openFileDialog.Title = "Abrir";

            // TODO:
        }
        private void OnCLickSave(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            saveFileDialog.Title = "Guardar Como";

            // TODO:
        }
        private void OnClickEdition(object sender, RoutedEventArgs e)
        {
            // TODO:
        }
    }
}
