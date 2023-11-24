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
public class DrawerView : Form
{

    private Panel panelMain;
    private Button buttonNorth;
    private Button buttonSouth;
    private Button buttonEast;
    private Button buttonWest;
    private Button buttonCenter;
    public DrawerView()
    {
        InitializeComponent();
    }

    public Button ButtonCenter { get => buttonCenter; set => buttonCenter = value; }

    private void InitializeComponent()
    {
        // Declaraciones
        panelMain = new Panel();
        buttonNorth = new Button();
        buttonSouth = new Button();
        buttonEast = new Button();
        buttonWest = new Button();
        buttonCenter = new Button();

        // Instancias
        SuspendLayout();

        panelMain = new Panel();
        buttonNorth = new Button();
        buttonSouth = new Button();
        buttonEast = new Button();
        buttonWest = new Button();
        buttonCenter = new Button();


        // Añadimos
        panelMain.Controls.Add(buttonNorth);
        panelMain.Controls.Add(buttonSouth);
        panelMain.Controls.Add(buttonEast);
        panelMain.Controls.Add(buttonWest);
        panelMain.Controls.Add(buttonCenter);

        // Detalles
        panelMain.Dock = DockStyle.Fill;
        buttonNorth.Dock = DockStyle.Top;
        buttonNorth.Text = "North";
        buttonNorth.AutoSize = true;
        buttonSouth.Dock = DockStyle.Bottom;
        buttonSouth.Text = "South";
        buttonSouth.AutoSize = true;
        buttonEast.Dock = DockStyle.Right;
        buttonEast.Text = "East";
        buttonEast.AutoSize = true;
        buttonWest.Dock = DockStyle.Left;
        buttonWest.Text = "West";
        buttonWest.AutoSize = true;
        buttonCenter.Dock = DockStyle.Fill;
        buttonCenter.Text = "CounterApp";
        buttonCenter.AutoSize = true;


        // Componemos
        Controls.Add(panelMain);
        ResumeLayout();
        PerformLayout();
    }
}

