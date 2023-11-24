using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormSegundo.views.lastViews;
public class CounterView : Form
{
    private Button buttonPlus;
    private Button buttonMinus;
    private TableLayoutPanel tableButtons;
    private TableLayoutPanel panelMain;
    private Label labelCounter;

    public CounterView()
    {
        InitializeComponent();
    }

    public Button ButtonPlus { get => buttonPlus; set => buttonPlus = value; }
    public Button ButtonMinus { get => buttonMinus; set => buttonMinus = value; }
    public Label LabelCounter { get => labelCounter; set => labelCounter = value; }

    private void InitializeComponent()
    {
        panelMain = new TableLayoutPanel();
        labelCounter = new Label();
        tableButtons = new TableLayoutPanel();
        buttonPlus = new Button();
        buttonMinus = new Button();
        tableButtons.SuspendLayout();
        panelMain.SuspendLayout();
        SuspendLayout();
        // 
        // panelMain
        // 
        panelMain.ColumnCount = 1;
        panelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        panelMain.Controls.Add(labelCounter, 0, 0);
        panelMain.Controls.Add(tableButtons, 0, 1);
        panelMain.Location = new Point(31, 76);
        panelMain.Name = "panelMain";
        panelMain.RowCount = 2;
        panelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        panelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        panelMain.Size = new Size(300, 150);
        panelMain.TabIndex = 1;
        panelMain.Dock = DockStyle.Fill;
        // 
        // labelCounter
        // 
        labelCounter.Location = new Point(3, 0);
        labelCounter.Name = "labelCounter";
        labelCounter.Size = new Size(100, 23);
        labelCounter.TabIndex = 0;
        labelCounter.Text = "0";
        //labelCounter.Location = ;
        labelCounter.Dock = DockStyle.Fill;
        // 
        // tableButtons
        // 
        tableButtons.ColumnCount = 2;
        tableButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableButtons.Controls.Add(buttonPlus, 0, 0);
        tableButtons.Controls.Add(buttonMinus, 1, 0);
        tableButtons.Location = new Point(3, 78);
        tableButtons.Name = "tableButtons";
        tableButtons.RowCount = 1;
        tableButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableButtons.Size = new Size(294, 69);
        tableButtons.TabIndex = 0;
        tableButtons.Dock = DockStyle.Fill;
        // 
        // buttonPlus
        // 
        buttonPlus.Dock = DockStyle.Fill;
        buttonPlus.Location = new Point(3, 3);
        buttonPlus.Name = "buttonPlus";
        buttonPlus.Size = new Size(141, 63);
        buttonPlus.TabIndex = 0;
        buttonPlus.Text = "+";
        buttonPlus.UseVisualStyleBackColor = true;
        buttonPlus.Dock = DockStyle.Fill;
        // 
        // buttonMinus
        // 
        buttonMinus.Dock = DockStyle.Fill;
        buttonMinus.Location = new Point(150, 3);
        buttonMinus.Name = "buttonMinus";
        buttonMinus.Size = new Size(141, 63);
        buttonMinus.TabIndex = 1;
        buttonMinus.Text = "-";
        buttonMinus.UseVisualStyleBackColor = true;
        buttonMinus.Dock = DockStyle.Fill;
        // 
        // CounterView
        // 
        ClientSize = new Size(373, 312);
        Controls.Add(panelMain);
        Name = "CounterView";
        panelMain.ResumeLayout(false);
        tableButtons.ResumeLayout(false);
        panelMain.ResumeLayout(false);
        ResumeLayout(false);
    }
}

