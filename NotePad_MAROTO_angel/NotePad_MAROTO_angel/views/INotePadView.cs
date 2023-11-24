namespace views;
internal interface INotePadView
{
    string CurrentFilePath { get; set; }
    TextBox TextBoxNote { get; set; }

    event EventHandler NewFile;
    event EventHandler OpenFile;
    event EventHandler SaveFile;
    event EventHandler SaveAsFile;
    event EventHandler PrintFile;
    event EventHandler Undo;
    event EventHandler Copy;
    event EventHandler Cut;
    event EventHandler Paste;
    event EventHandler Delete;
    event EventHandler Source;
    event EventHandler StatusBar;
    event EventHandler About;
    event EventHandler ShowWeb;
    event EventHandler EditBackgroundColor;
}

