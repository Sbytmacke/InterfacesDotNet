namespace P03_03_DI_Contactos_MAROTO_angel
{
    partial class ContactsView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            departmentTitle = new Label();
            employeeTitle = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableDepartments = new DataGridView();
            NameDepartment = new DataGridViewTextBoxColumn();
            tableEmployees = new DataGridView();
            NameEmployee = new DataGridViewTextBoxColumn();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            positionTextBox = new TextBox();
            phoneTextBox = new TextBox();
            emailTextBox = new TextBox();
            nameTextBox = new TextBox();
            dniTextBox = new TextBox();
            departmentLabel = new Label();
            positionLabel = new Label();
            phoneLabel = new Label();
            emailLabel = new Label();
            nameLabel = new Label();
            dniLabel = new Label();
            departmentTextBox = new TextBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newMenuItem = new ToolStripMenuItem();
            openMenuItem = new ToolStripMenuItem();
            saveMenuItem = new ToolStripMenuItem();
            saveAsMenuItem = new ToolStripMenuItem();
            updateEmployeeButton = new Button();
            imageEmployee = new PictureBox();
            deleteEmployeeButton = new Button();
            newEmployeeButton = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tableDepartments).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tableEmployees).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imageEmployee).BeginInit();
            SuspendLayout();
            // 
            // departmentTitle
            // 
            departmentTitle.AutoSize = true;
            departmentTitle.Dock = DockStyle.Fill;
            departmentTitle.Font = new Font("Sans Serif Collection", 9.999999F, FontStyle.Regular, GraphicsUnit.Point);
            departmentTitle.Location = new Point(3, 0);
            departmentTitle.Name = "departmentTitle";
            departmentTitle.Size = new Size(263, 64);
            departmentTitle.TabIndex = 0;
            departmentTitle.Text = "Departamentos";
            departmentTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // employeeTitle
            // 
            employeeTitle.AutoSize = true;
            employeeTitle.Dock = DockStyle.Fill;
            employeeTitle.Font = new Font("Sans Serif Collection", 9.999999F, FontStyle.Regular, GraphicsUnit.Point);
            employeeTitle.Location = new Point(272, 0);
            employeeTitle.Name = "employeeTitle";
            employeeTitle.Size = new Size(263, 64);
            employeeTitle.TabIndex = 1;
            employeeTitle.Text = "Empleados";
            employeeTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(departmentTitle, 0, 0);
            tableLayoutPanel1.Controls.Add(employeeTitle, 1, 0);
            tableLayoutPanel1.Controls.Add(tableDepartments, 0, 1);
            tableLayoutPanel1.Controls.Add(tableEmployees, 1, 1);
            tableLayoutPanel1.Location = new Point(23, 49);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.77642775F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 92.22357F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(538, 823);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // tableDepartments
            // 
            tableDepartments.AllowUserToAddRows = false;
            tableDepartments.AllowUserToDeleteRows = false;
            tableDepartments.AllowUserToResizeColumns = false;
            tableDepartments.AllowUserToResizeRows = false;
            tableDepartments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableDepartments.Columns.AddRange(new DataGridViewColumn[] { NameDepartment });
            tableDepartments.Location = new Point(3, 67);
            tableDepartments.MultiSelect = false;
            tableDepartments.Name = "tableDepartments";
            tableDepartments.ReadOnly = true;
            tableDepartments.RowHeadersWidth = 62;
            tableDepartments.RowTemplate.Height = 33;
            tableDepartments.SelectionMode = DataGridViewSelectionMode.CellSelect;
            tableDepartments.Size = new Size(263, 753);
            tableDepartments.TabIndex = 2;
            // 
            // NameDepartment
            // 
            NameDepartment.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            NameDepartment.HeaderText = "Nombre";
            NameDepartment.MinimumWidth = 8;
            NameDepartment.Name = "NameDepartment";
            NameDepartment.ReadOnly = true;
            NameDepartment.Resizable = DataGridViewTriState.False;
            // 
            // tableEmployees
            // 
            tableEmployees.AllowUserToAddRows = false;
            tableEmployees.AllowUserToDeleteRows = false;
            tableEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableEmployees.Columns.AddRange(new DataGridViewColumn[] { NameEmployee });
            tableEmployees.Location = new Point(272, 67);
            tableEmployees.Name = "tableEmployees";
            tableEmployees.ReadOnly = true;
            tableEmployees.RowHeadersWidth = 62;
            tableEmployees.RowTemplate.Height = 33;
            tableEmployees.Size = new Size(263, 753);
            tableEmployees.TabIndex = 3;
            // 
            // NameEmployee
            // 
            NameEmployee.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            NameEmployee.HeaderText = "Nombre";
            NameEmployee.MinimumWidth = 8;
            NameEmployee.Name = "NameEmployee";
            NameEmployee.ReadOnly = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(200, 100);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(positionTextBox, 0, 11);
            tableLayoutPanel3.Controls.Add(phoneTextBox, 0, 9);
            tableLayoutPanel3.Controls.Add(emailTextBox, 0, 7);
            tableLayoutPanel3.Controls.Add(nameTextBox, 0, 5);
            tableLayoutPanel3.Controls.Add(dniTextBox, 0, 3);
            tableLayoutPanel3.Controls.Add(departmentLabel, 0, 0);
            tableLayoutPanel3.Controls.Add(positionLabel, 0, 10);
            tableLayoutPanel3.Controls.Add(phoneLabel, 0, 8);
            tableLayoutPanel3.Controls.Add(emailLabel, 0, 6);
            tableLayoutPanel3.Controls.Add(nameLabel, 0, 4);
            tableLayoutPanel3.Controls.Add(dniLabel, 0, 2);
            tableLayoutPanel3.Controls.Add(departmentTextBox, 0, 1);
            tableLayoutPanel3.Location = new Point(644, 281);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 12;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            tableLayoutPanel3.Size = new Size(425, 480);
            tableLayoutPanel3.TabIndex = 3;
            // 
            // positionTextBox
            // 
            positionTextBox.Dock = DockStyle.Fill;
            positionTextBox.Location = new Point(3, 432);
            positionTextBox.Name = "positionTextBox";
            positionTextBox.Size = new Size(419, 31);
            positionTextBox.TabIndex = 16;
            // 
            // phoneTextBox
            // 
            phoneTextBox.Dock = DockStyle.Fill;
            phoneTextBox.Location = new Point(3, 354);
            phoneTextBox.Name = "phoneTextBox";
            phoneTextBox.Size = new Size(419, 31);
            phoneTextBox.TabIndex = 15;
            // 
            // emailTextBox
            // 
            emailTextBox.Dock = DockStyle.Fill;
            emailTextBox.Location = new Point(3, 276);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(419, 31);
            emailTextBox.TabIndex = 14;
            // 
            // nameTextBox
            // 
            nameTextBox.Dock = DockStyle.Fill;
            nameTextBox.Location = new Point(3, 198);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(419, 31);
            nameTextBox.TabIndex = 13;
            // 
            // dniTextBox
            // 
            dniTextBox.Dock = DockStyle.Fill;
            dniTextBox.Location = new Point(3, 120);
            dniTextBox.Name = "dniTextBox";
            dniTextBox.Size = new Size(419, 31);
            dniTextBox.TabIndex = 12;
            // 
            // departmentLabel
            // 
            departmentLabel.AutoSize = true;
            departmentLabel.Dock = DockStyle.Fill;
            departmentLabel.Location = new Point(3, 0);
            departmentLabel.Name = "departmentLabel";
            departmentLabel.Size = new Size(419, 39);
            departmentLabel.TabIndex = 0;
            departmentLabel.Text = "Departamento:";
            departmentLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // positionLabel
            // 
            positionLabel.AutoSize = true;
            positionLabel.Dock = DockStyle.Fill;
            positionLabel.Location = new Point(3, 390);
            positionLabel.Name = "positionLabel";
            positionLabel.Size = new Size(419, 39);
            positionLabel.TabIndex = 6;
            positionLabel.Text = "Posición:";
            positionLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize = true;
            phoneLabel.Dock = DockStyle.Fill;
            phoneLabel.Location = new Point(3, 312);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Size = new Size(419, 39);
            phoneLabel.TabIndex = 7;
            phoneLabel.Text = "Teléfono:";
            phoneLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Dock = DockStyle.Fill;
            emailLabel.Location = new Point(3, 234);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(419, 39);
            emailLabel.TabIndex = 8;
            emailLabel.Text = "Correo electrónico:";
            emailLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Dock = DockStyle.Fill;
            nameLabel.Location = new Point(3, 156);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(419, 39);
            nameLabel.TabIndex = 9;
            nameLabel.Text = "Nombre:";
            nameLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dniLabel
            // 
            dniLabel.AutoSize = true;
            dniLabel.Dock = DockStyle.Fill;
            dniLabel.Location = new Point(3, 78);
            dniLabel.Name = "dniLabel";
            dniLabel.Size = new Size(419, 39);
            dniLabel.TabIndex = 10;
            dniLabel.Text = "DNI:";
            dniLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // departmentTextBox
            // 
            departmentTextBox.Dock = DockStyle.Fill;
            departmentTextBox.Location = new Point(3, 42);
            departmentTextBox.Name = "departmentTextBox";
            departmentTextBox.Size = new Size(419, 31);
            departmentTextBox.TabIndex = 11;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1133, 33);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newMenuItem, openMenuItem, saveMenuItem, saveAsMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(88, 29);
            fileToolStripMenuItem.Text = "Archivo";
            // 
            // newMenuItem
            // 
            newMenuItem.Name = "newMenuItem";
            newMenuItem.Size = new Size(228, 34);
            newMenuItem.Text = "Nuevo";
            // 
            // openMenuItem
            // 
            openMenuItem.Name = "openMenuItem";
            openMenuItem.Size = new Size(228, 34);
            openMenuItem.Text = "Abrir";
            // 
            // saveMenuItem
            // 
            saveMenuItem.Name = "saveMenuItem";
            saveMenuItem.Size = new Size(228, 34);
            saveMenuItem.Text = "Guardar";
            // 
            // saveAsMenuItem
            // 
            saveAsMenuItem.Name = "saveAsMenuItem";
            saveAsMenuItem.Size = new Size(228, 34);
            saveAsMenuItem.Text = "Guardar como";
            // 
            // updateEmployeeButton
            // 
            updateEmployeeButton.Location = new Point(674, 801);
            updateEmployeeButton.Name = "updateEmployeeButton";
            updateEmployeeButton.Size = new Size(112, 34);
            updateEmployeeButton.TabIndex = 5;
            updateEmployeeButton.Text = "Actualizar";
            updateEmployeeButton.UseVisualStyleBackColor = true;
            // 
            // imageEmployee
            // 
            imageEmployee.Location = new Point(762, 69);
            imageEmployee.Name = "imageEmployee";
            imageEmployee.Size = new Size(190, 178);
            imageEmployee.SizeMode = PictureBoxSizeMode.Zoom;
            imageEmployee.TabIndex = 7;
            imageEmployee.TabStop = false;
            // 
            // deleteEmployeeButton
            // 
            deleteEmployeeButton.Location = new Point(801, 801);
            deleteEmployeeButton.Name = "deleteEmployeeButton";
            deleteEmployeeButton.Size = new Size(112, 34);
            deleteEmployeeButton.TabIndex = 8;
            deleteEmployeeButton.Text = "Eliminar";
            deleteEmployeeButton.UseVisualStyleBackColor = true;
            // 
            // newEmployeeButton
            // 
            newEmployeeButton.Location = new Point(930, 801);
            newEmployeeButton.Name = "newEmployeeButton";
            newEmployeeButton.Size = new Size(112, 34);
            newEmployeeButton.TabIndex = 9;
            newEmployeeButton.Text = "Nuevo";
            newEmployeeButton.UseVisualStyleBackColor = true;
            // 
            // ContactsView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1133, 909);
            Controls.Add(newEmployeeButton);
            Controls.Add(deleteEmployeeButton);
            Controls.Add(imageEmployee);
            Controls.Add(updateEmployeeButton);
            Controls.Add(tableLayoutPanel3);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "ContactsView";
            Text = "ContactsView";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tableDepartments).EndInit();
            ((System.ComponentModel.ISupportInitialize)tableEmployees).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)imageEmployee).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label departmentTitle;
        private Label employeeTitle;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private Label departmentLabel;
        private Label positionLabel;
        private Label phoneLabel;
        private Label emailLabel;
        private Label nameLabel;
        private Label dniLabel;
        private TextBox departmentTextBox;
        private TextBox positionTextBox;
        private TextBox phoneTextBox;
        private TextBox emailTextBox;
        private TextBox nameTextBox;
        private TextBox dniTextBox;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        public DataGridView tableDepartments;
        public DataGridView tableEmployees;
        private DataGridViewTextBoxColumn NameDepartment;
        private DataGridViewTextBoxColumn NameEmployee;
        private Button updateEmployeeButton;
        private PictureBox imageEmployee;
        private Button deleteEmployeeButton;
        private Button newEmployeeButton;
        private ToolStripMenuItem newMenuItem;
        private ToolStripMenuItem openMenuItem;
        private ToolStripMenuItem saveMenuItem;
        private ToolStripMenuItem saveAsMenuItem;
    }
}