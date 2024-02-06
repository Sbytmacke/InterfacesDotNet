namespace Maroto_Chivite_Angel_App_Sorteo;
partial class MainView
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        textBoxUser = new TextBox();
        addName = new Button();
        addPrice = new Button();
        randomWinner = new Button();
        newPrice = new Button();
        tableLayoutPanel1 = new TableLayoutPanel();
        tableLayoutPanel2 = new TableLayoutPanel();
        panel1 = new Panel();
        dataGridUsers = new DataGridView();
        panel2 = new Panel();
        dataGridPrices = new DataGridView();
        textBoxPrice = new TextBox();
        NamePrice = new DataGridViewTextBoxColumn();
        NameUser = new DataGridViewTextBoxColumn();
        tableLayoutPanel1.SuspendLayout();
        tableLayoutPanel2.SuspendLayout();
        panel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridUsers).BeginInit();
        panel2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridPrices).BeginInit();
        SuspendLayout();
        // 
        // textBoxUser
        // 
        textBoxUser.Dock = DockStyle.Top;
        textBoxUser.Location = new Point(0, 0);
        textBoxUser.Name = "textBoxUser";
        textBoxUser.Size = new Size(294, 31);
        textBoxUser.TabIndex = 0;
        // 
        // addName
        // 
        addName.Dock = DockStyle.Fill;
        addName.Location = new Point(3, 3);
        addName.Name = "addName";
        addName.Size = new Size(172, 297);
        addName.TabIndex = 2;
        addName.Text = "Añadir nombre";
        addName.UseVisualStyleBackColor = true;
        // 
        // addPrice
        // 
        addPrice.Dock = DockStyle.Fill;
        addPrice.Location = new Point(181, 3);
        addPrice.Name = "addPrice";
        addPrice.Size = new Size(172, 297);
        addPrice.TabIndex = 3;
        addPrice.Text = "Añadir premio";
        addPrice.UseVisualStyleBackColor = true;
        // 
        // randomWinner
        // 
        randomWinner.Dock = DockStyle.Fill;
        randomWinner.Location = new Point(3, 306);
        randomWinner.Name = "randomWinner";
        randomWinner.Size = new Size(172, 298);
        randomWinner.TabIndex = 4;
        randomWinner.Text = "¡Sortear!";
        randomWinner.UseVisualStyleBackColor = true;
        // 
        // newPrice
        // 
        newPrice.Dock = DockStyle.Fill;
        newPrice.Location = new Point(181, 306);
        newPrice.Name = "newPrice";
        newPrice.Size = new Size(172, 298);
        newPrice.TabIndex = 5;
        newPrice.Text = "Nuevo sorteo";
        newPrice.UseVisualStyleBackColor = true;
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 3;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45.30612F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 54.69388F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 302F));
        tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 0);
        tableLayoutPanel1.Controls.Add(panel1, 0, 0);
        tableLayoutPanel1.Controls.Add(panel2, 2, 0);
        tableLayoutPanel1.Dock = DockStyle.Fill;
        tableLayoutPanel1.Location = new Point(0, 0);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 1;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tableLayoutPanel1.Size = new Size(965, 613);
        tableLayoutPanel1.TabIndex = 6;
        // 
        // tableLayoutPanel2
        // 
        tableLayoutPanel2.ColumnCount = 2;
        tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanel2.Controls.Add(addName, 0, 0);
        tableLayoutPanel2.Controls.Add(addPrice, 1, 0);
        tableLayoutPanel2.Controls.Add(newPrice, 1, 1);
        tableLayoutPanel2.Controls.Add(randomWinner, 0, 1);
        tableLayoutPanel2.Dock = DockStyle.Fill;
        tableLayoutPanel2.Location = new Point(303, 3);
        tableLayoutPanel2.Name = "tableLayoutPanel2";
        tableLayoutPanel2.RowCount = 2;
        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutPanel2.Size = new Size(356, 607);
        tableLayoutPanel2.TabIndex = 6;
        // 
        // panel1
        // 
        panel1.Controls.Add(dataGridUsers);
        panel1.Controls.Add(textBoxUser);
        panel1.Dock = DockStyle.Fill;
        panel1.Location = new Point(3, 3);
        panel1.Name = "panel1";
        panel1.Size = new Size(294, 607);
        panel1.TabIndex = 7;
        // 
        // dataGridUsers
        // 
        dataGridUsers.AllowUserToAddRows = false;
        dataGridUsers.AllowUserToDeleteRows = false;
        dataGridUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridUsers.Columns.AddRange(new DataGridViewColumn[] { NameUser });
        dataGridUsers.Dock = DockStyle.Fill;
        dataGridUsers.Location = new Point(0, 31);
        dataGridUsers.Name = "dataGridUsers";
        dataGridUsers.ReadOnly = true;
        dataGridUsers.RowHeadersWidth = 62;
        dataGridUsers.RowTemplate.Height = 33;
        dataGridUsers.Size = new Size(294, 576);
        dataGridUsers.TabIndex = 1;
        // 
        // panel2
        // 
        panel2.Controls.Add(dataGridPrices);
        panel2.Controls.Add(textBoxPrice);
        panel2.Dock = DockStyle.Fill;
        panel2.Location = new Point(665, 3);
        panel2.Name = "panel2";
        panel2.Size = new Size(297, 607);
        panel2.TabIndex = 8;
        // 
        // dataGridPrices
        // 
        dataGridPrices.AllowUserToAddRows = false;
        dataGridPrices.AllowUserToDeleteRows = false;
        dataGridPrices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridPrices.Columns.AddRange(new DataGridViewColumn[] { NamePrice });
        dataGridPrices.Dock = DockStyle.Fill;
        dataGridPrices.Location = new Point(0, 31);
        dataGridPrices.Name = "dataGridPrices";
        dataGridPrices.ReadOnly = true;
        dataGridPrices.RowHeadersWidth = 62;
        dataGridPrices.RowTemplate.Height = 33;
        dataGridPrices.Size = new Size(297, 576);
        dataGridPrices.TabIndex = 1;
        // 
        // textBoxPrice
        // 
        textBoxPrice.Dock = DockStyle.Top;
        textBoxPrice.Location = new Point(0, 0);
        textBoxPrice.Name = "textBoxPrice";
        textBoxPrice.Size = new Size(297, 31);
        textBoxPrice.TabIndex = 0;
        // 
        // NamePrice
        // 
        NamePrice.HeaderText = "Premios";
        NamePrice.MinimumWidth = 8;
        NamePrice.Name = "NamePrice";
        NamePrice.ReadOnly = true;
        NamePrice.Width = 150;
        // 
        // NameUser
        // 
        NameUser.HeaderText = "Usuarios";
        NameUser.MinimumWidth = 8;
        NameUser.Name = "NameUser";
        NameUser.ReadOnly = true;
        NameUser.Width = 150;
        // 
        // MainView
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(965, 613);
        Controls.Add(tableLayoutPanel1);
        Name = "MainView";
        Text = "Form1";
        tableLayoutPanel1.ResumeLayout(false);
        tableLayoutPanel2.ResumeLayout(false);
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridUsers).EndInit();
        panel2.ResumeLayout(false);
        panel2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridPrices).EndInit();
        ResumeLayout(false);
    }

    #endregion

    public TextBox textBoxUser;
    private Button addName;
    private Button addPrice;
    private Button randomWinner;
    private Button newPrice;
    private TableLayoutPanel tableLayoutPanel1;
    private TableLayoutPanel tableLayoutPanel2;
    private Panel panel1;
    public DataGridView dataGridUsers;
    private Panel panel2;
    public DataGridView dataGridPrices;
    public TextBox textBoxPrice;
    private DataGridViewTextBoxColumn NameUser;
    private DataGridViewTextBoxColumn NamePrice;
}