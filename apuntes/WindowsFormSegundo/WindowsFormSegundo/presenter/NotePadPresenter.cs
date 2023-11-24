using System.Diagnostics;
using System.Drawing.Printing;
using WindowsFormSegundo.views;

namespace WindowsFormSegundo.presenter;
internal class NotePadPresenter
{
    private NotePadView notePadView;

    private Stack<string> undoStack = new Stack<string>();

    public NotePadPresenter(NotePadView notePadView)
    {
        this.notePadView = notePadView;

        // Asociamos la lógica de los eventos con los métodos de la vista
        notePadView.NewFile += NewFile;
        notePadView.OpenFile += OpenFile;
        notePadView.SaveFile += SaveMenuItem;
        notePadView.SaveAsFile += SaveAsMenuItem;
        notePadView.PrintFile += PrintFile;
        notePadView.Undo += Undo;
        // Cada vez que el texto en el cuadro de texto cambia, agregamos al historial de deshacer
        notePadView.TextBoxNote.TextChanged += (sender, e) => AddTextToUndoStack(sender, e);
        // Añadimos un estado inicial al historial de deshacer
        undoStack.Push(notePadView.TextBoxNote.Text);
        notePadView.Copy += Copy;
        notePadView.Cut += Cut;
        notePadView.Paste += Paste;
        notePadView.Delete += Delete;
        notePadView.Source += Source;
        notePadView.StatusBar += StatusBar;
        notePadView.About += About;
        notePadView.ShowWeb += ShowWeb;

        // Parte opcional
        notePadView.EditBackgroundColor += EditBackgroundColor;
    }

    private void NewFile(object sender, EventArgs e)
    {
        DialogResult result = MessageBox.Show("¿Desea guardar el archivo actual?", "Guardar archivo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            if (notePadView.CurrentFilePath == null)
            {
                SaveAsMenuItem(sender, e);
            }
            else
            {
                SaveMenuItem(sender, e);
            }
        }

        notePadView.TextBoxNote.Text = "";
        notePadView.CurrentFilePath = null;
    }

    private void OpenFile(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
        openFileDialog.Title = "Abrir";

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            string filePath = openFileDialog.FileName;
            notePadView.CurrentFilePath = filePath;
            notePadView.TextBoxNote.Text = File.ReadAllText(filePath);
        }
    }

    private void SaveMenuItem(object sender, EventArgs e)
    {
        // Verificamos si ya se ha guardado el archivo
        if (notePadView.CurrentFilePath == null)
        {
            SaveAsMenuItem(sender, e);
        }
        else
        {
            // Si ya se ha guardado, sobrescribimos el archivo
            try
            {
                File.WriteAllText(notePadView.CurrentFilePath, notePadView.Text);
                MessageBox.Show("Cambios guardados correctamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void SaveAsMenuItem(object sender, EventArgs e)
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
        saveFileDialog.Title = "Guardar Como";

        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            string filePath = saveFileDialog.FileName;

            // Guardar el contenido del textBox en el archivo seleccionado
            try
            {
                File.WriteAllText(filePath, notePadView.TextBoxNote.Text);
                notePadView.CurrentFilePath = filePath;
                MessageBox.Show("Archivo guardado correctamente.", "Guardar Como", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void PrintFile(object sender, EventArgs e)
    {
        PrintDialog printDialog = new PrintDialog();
        PrintDocument printDocument = new PrintDocument();

        printDialog.Document = printDocument;

        if (printDialog.ShowDialog() == DialogResult.OK)
        {
            printDocument.PrintPage += (sender, ev) =>
            {
                // Dibujamos el contenido para imprimir con el formato que deseemos
                string textToPrint = notePadView.TextBoxNote.Text;
                Font printFont = new Font("Arial", 10);
                ev.Graphics.DrawString(textToPrint, printFont, Brushes.Black, ev.MarginBounds.Left, ev.MarginBounds.Top, new StringFormat());
            };

            try
            {
                printDocument.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void AddTextToUndoStack(object sender, EventArgs e)
    {
        undoStack.Push(notePadView.TextBoxNote.Text);
    }

    private void Undo(object sender, EventArgs e)
    {
        if (undoStack.Count > 1) // Verificamos si hay al menos dos estados en el historial
        {
            // Deshacemos la última acción pop y obtenemos el estado anterior (pero no podríamos recuperarlo)
            undoStack.Pop();
            string previousText = undoStack.Peek();

            // Asignamos el estado anterior al cuadro de texto
            notePadView.TextBoxNote.Text = previousText;
        }
    }

    private void Copy(object sender, EventArgs e)
    {
        if (notePadView.TextBoxNote.SelectedText != "")
        {
            Clipboard.SetText(notePadView.TextBoxNote.SelectedText);
        }
    }

    private void Cut(object sender, EventArgs e)
    {
        if (notePadView.TextBoxNote.SelectedText != "")
        {
            Clipboard.SetText(notePadView.TextBoxNote.SelectedText);
            notePadView.TextBoxNote.SelectedText = "";
        }
    }

    private void Paste(object sender, EventArgs e)
    {
        if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
        {
            notePadView.TextBoxNote.Paste();
        }
    }

    private void Delete(object sender, EventArgs e)
    {
        if (notePadView.TextBoxNote.SelectedText != "")
        {
            notePadView.TextBoxNote.SelectedText = "";
        }
    }

    private void Source(object sender, EventArgs e)
    {
        FontDialog fontDialog = new FontDialog();

        if (fontDialog.ShowDialog() == DialogResult.OK)
        {
            Font selectedFont = fontDialog.Font;
            notePadView.TextBoxNote.Font = selectedFont;
        }
    }

    private void StatusBar(object sender, EventArgs e)
    {
        if (notePadView.statusBar.Visible)
        {
            notePadView.statusBar.Visible = false;
        }
        else
        {
            notePadView.statusBar.Visible = true;
        }
    }

    private void About(object sender, EventArgs e)
    {
        string authorInfo = "NotePad\n\nAutor: Angel Maroto Chivite\nVersión: 1.0";
        MessageBox.Show(authorInfo, "Acerca de", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void ShowWeb(object sender, EventArgs e)
    {
        string url = "https://sbytmacke.github.io/curriculum-web/";
        string explorer = "explorer.exe";
        try
        {
            Process.Start(explorer, url);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al abrir la URL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Parte opcional
    private void EditBackgroundColor(object sender, EventArgs e)
    {
        ColorDialog colorDialog = new ColorDialog();

        if (colorDialog.ShowDialog() == DialogResult.OK)
        {
            notePadView.TextBoxNote.BackColor = colorDialog.Color;
        }
    }

    internal Form init()
    {
        return notePadView;
    }
}


