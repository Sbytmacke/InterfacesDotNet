namespace views;

public class NotePadView : Form, INotePadView
{
    public string? CurrentFilePath { get; set; }
    public TextBox TextBoxNote { get; set; }

    private MenuStrip menuStrip;
    public StatusStrip statusBar;

    public NotePadView()
    {
        CurrentFilePath = null;
        InitializeComponent();
        UpdateCursorPosition();
    }

    public event EventHandler NewFile;
    public event EventHandler OpenFile;
    public event EventHandler SaveFile;
    public event EventHandler SaveAsFile;
    public event EventHandler PrintFile;
    public event EventHandler Undo;
    public event EventHandler Copy;
    public event EventHandler Cut;
    public event EventHandler Paste;
    public event EventHandler Delete;
    public event EventHandler Source;
    public event EventHandler StatusBar;
    public event EventHandler About;
    public event EventHandler ShowWeb;
    public event EventHandler EditBackgroundColor;
    private void InitializeComponent()
    {
        menuStrip = new MenuStrip();
        TextBoxNote = new TextBox();
        statusBar = new StatusStrip();
        SuspendLayout();
        // 
        // MenuStrip
        // 
        menuStrip.ImageScalingSize = new Size(24, 24);
        menuStrip.Location = new Point(0, 0);
        menuStrip.Name = "menuStrip";
        menuStrip.Size = new Size(800, 24);
        menuStrip.TabIndex = 1;
        menuStrip.Text = "menuStrip";
        // Archivo
        ToolStripMenuItem archiveMenuItem = new ToolStripMenuItem("Archivo");
        ToolStripMenuItem newMenuItem = new ToolStripMenuItem("Nuevo");
        ToolStripMenuItem openMenuItem = new ToolStripMenuItem("Abrir");
        ToolStripMenuItem saveMenuItem = new ToolStripMenuItem("Guardar");
        ToolStripMenuItem saveAsMenuItem = new ToolStripMenuItem("Guardar Como");
        ToolStripMenuItem printMenuItem = new ToolStripMenuItem("Imprimir");
        archiveMenuItem.DropDownItems.Add(newMenuItem);
        archiveMenuItem.DropDownItems.Add(openMenuItem);
        archiveMenuItem.DropDownItems.Add(saveMenuItem);
        archiveMenuItem.DropDownItems.Add(saveAsMenuItem);
        archiveMenuItem.DropDownItems.Add(printMenuItem);
        newMenuItem.Click += (sender, e) => NewFile(sender, e);
        openMenuItem.Click += (sender, e) => OpenFile(sender, e);
        saveMenuItem.Click += (sender, e) => SaveFile(sender, e);
        saveAsMenuItem.Click += (sender, e) => SaveAsFile(sender, e);
        printMenuItem.Click += (sender, e) => PrintFile(sender, e);
        // Edición
        ToolStripMenuItem editMenuItem = new ToolStripMenuItem("Edición");
        ToolStripMenuItem undoMenuItem = new ToolStripMenuItem("Deshacer");
        ToolStripMenuItem copyMenuItem = new ToolStripMenuItem("Copiar");
        ToolStripMenuItem cutMenuItem = new ToolStripMenuItem("Cortar");
        ToolStripMenuItem pasteMenuItem = new ToolStripMenuItem("Pegar");
        ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("Eliminar");
        editMenuItem.DropDownItems.Add(undoMenuItem);
        editMenuItem.DropDownItems.Add(copyMenuItem);
        editMenuItem.DropDownItems.Add(cutMenuItem);
        editMenuItem.DropDownItems.Add(pasteMenuItem);
        editMenuItem.DropDownItems.Add(deleteMenuItem);
        undoMenuItem.Click += (sender, e) => Undo(sender, e);
        copyMenuItem.Click += (sender, e) => Copy(sender, e);
        // Mejora de la lógica del menú de copiar
        copyMenuItem.DropDownOpening += (sender, e) => UpdateCopyMenuItemEnabled(sender, e);
        cutMenuItem.Click += (sender, e) => Cut(sender, e);
        pasteMenuItem.Click += (sender, e) => Paste(sender, e);
        // Mejora de la lógica del menú de pegar
        pasteMenuItem.DropDownOpening += (sender, e) => UpdatePasteMenuItemEnabled(sender, e);
        deleteMenuItem.Click += (sender, e) => Delete(sender, e);
        // Formato
        ToolStripMenuItem formatMenuItem = new ToolStripMenuItem("Formato");
        ToolStripMenuItem sourceMenuItem = new ToolStripMenuItem("Fuente");
        ToolStripMenuItem backgroundColorMenuItem = new ToolStripMenuItem("Color");
        ToolStripMenuItem wordWrapMenuItem = new ToolStripMenuItem("Ajuste de Línea");
        formatMenuItem.DropDownItems.Add(sourceMenuItem);
        formatMenuItem.DropDownItems.Add(backgroundColorMenuItem);
        formatMenuItem.DropDownItems.Add(wordWrapMenuItem);
        sourceMenuItem.Click += (sender, e) => Source(sender, e);
        backgroundColorMenuItem.Click += (sender, e) => EditBackgroundColor(sender, e);
        wordWrapMenuItem.Click += (sender, e) => ToggleWordWrap(sender, e);
        // Ver
        ToolStripMenuItem showMenuItem = new ToolStripMenuItem("Ver");
        ToolStripMenuItem statusBarMenuItem = new ToolStripMenuItem("Barra de Estado");
        showMenuItem.DropDownItems.Add(statusBarMenuItem);
        statusBarMenuItem.Click += (sender, e) => StatusBar(sender, e);
        // Ayuda
        ToolStripMenuItem helpMenuItem = new ToolStripMenuItem("Ayuda");
        ToolStripMenuItem aboutMenuItem = new ToolStripMenuItem("Acerca de");
        ToolStripMenuItem showWebMenuItem = new ToolStripMenuItem("Ver Ayuda");
        helpMenuItem.DropDownItems.Add(aboutMenuItem);
        helpMenuItem.DropDownItems.Add(showWebMenuItem);
        aboutMenuItem.Click += (sender, e) => About(sender, e);
        showWebMenuItem.Click += (sender, e) => ShowWeb(sender, e);
        // Agregamos todos los elementos
        menuStrip.Items.Add(archiveMenuItem);
        menuStrip.Items.Add(editMenuItem);
        menuStrip.Items.Add(formatMenuItem);
        menuStrip.Items.Add(showMenuItem);
        menuStrip.Items.Add(helpMenuItem);

        //
        // TextBox
        //
        TextBoxNote.Multiline = true;
        TextBoxNote.Dock = DockStyle.Fill;

        //
        // StatusBar
        //
        statusBar.Name = "statusBar";
        statusBar.Dock = DockStyle.Bottom;
        TextBoxNote.TextChanged += (sender, e) => UpdateCursorPosition();

        //
        // ContextMenu
        //
        ContextMenuStrip contextMenu = new ContextMenuStrip();
        ToolStripMenuItem copyContextMenuItem = new ToolStripMenuItem("Copiar");
        ToolStripMenuItem cutContextMenuItem = new ToolStripMenuItem("Cortar");
        ToolStripMenuItem pasteContextMenuItem = new ToolStripMenuItem("Pegar");
        contextMenu.Items.Add(copyContextMenuItem);
        contextMenu.Items.Add(cutContextMenuItem);
        contextMenu.Items.Add(pasteContextMenuItem);
        copyContextMenuItem.Click += (sender, e) => Copy(sender, e);
        cutContextMenuItem.Click += (sender, e) => Cut(sender, e);
        pasteContextMenuItem.Click += (sender, e) => Paste(sender, e);

        TextBoxNote.ContextMenuStrip = contextMenu;

        // 
        // NotePadView
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        // Debo ponerlo el primero si no queda oculto por el resto de controles
        Controls.Add(TextBoxNote);
        Controls.Add(menuStrip);
        Controls.Add(statusBar);

        MainMenuStrip = menuStrip;
        Name = "NotePad";
        Text = "NotePad";

        ResumeLayout(false);
        PerformLayout();
    }

    private void UpdateCursorPosition()
    {
        int selectionStart = TextBoxNote.SelectionStart;
        int line = TextBoxNote.GetLineFromCharIndex(selectionStart) + 1;
        int column = selectionStart - TextBoxNote.GetFirstCharIndexOfCurrentLine() + 1;

        // Actualizamos el texto en la barra de estado
        statusBar.Items.Clear();
        statusBar.Items.Add($"Fila: {line}, Columna: {column}");
    }

    private void UpdateCopyMenuItemEnabled(object sender, EventArgs e)
    {
        ToolStripMenuItem copyMenuItem = (ToolStripMenuItem)sender;
        copyMenuItem.Enabled = !string.IsNullOrEmpty(TextBoxNote.SelectedText);
    }

    private void UpdatePasteMenuItemEnabled(object sender, EventArgs e)
    {
        ToolStripMenuItem pasteMenuItem = (ToolStripMenuItem)sender;
        pasteMenuItem.Enabled = Clipboard.ContainsText();
    }

    private void ToggleWordWrap(object sender, EventArgs e)
    {
        TextBoxNote.WordWrap = !TextBoxNote.WordWrap;
    }
}