using Models;
using P03_03_DI_Contactos_MAROTO_angel.Presenters;
using P03_03_DI_Contactos_MAROTO_angel.Views;

namespace P03_03_DI_Contactos_MAROTO_angel
{
    public partial class ContactsView : Form, IContactsView
    {
        public string CurrentFilePath { get; set; }
        private ContactsPresenter presenter;
        private Department departmentSelected;
        private Employee employeeSelected;

        public event EventHandler NewFile;
        public event EventHandler OpenFile;
        public event EventHandler SaveFile;
        public event EventHandler SaveAsFile;

        public ContactsView()
        {
            InitializeComponent();
            InitializeEventHandlers();
            this.Paint += OnFormPaint;
        }

        private void InitializeEventHandlers()
        {
            tableDepartments.CellClick += OnClickDepartmentTable;
            tableEmployees.CellClick += OnClickEmployeeTable;
            deleteEmployeeButton.Click += OnClickDeleteEmployee;
            updateEmployeeButton.Click += OnClickUpdateEmployee;
            newEmployeeButton.Click += OnClickNewEmployee;
            imageEmployee.Click += OnClickImageEmployee;

            // Persistencia de datos
            newMenuItem.Click += (sender, e) => NewFile(sender, e);
            openMenuItem.Click += (sender, e) => OpenFile(sender, e);
            saveMenuItem.Click += (sender, e) => SaveFile(sender, e);
            saveAsMenuItem.Click += (sender, e) => SaveAsFile(sender, e);
        }

        private void OnClickImageEmployee(object? sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imageEmployee.ImageLocation = openFileDialog.FileName;
            }
        }

        private void OnClickNewEmployee(object? sender, EventArgs e)
        {
            string dni = dniTextBox.Text;
            string name = nameTextBox.Text;
            string email = emailTextBox.Text;
            string phone = phoneTextBox.Text;
            string position = positionTextBox.Text;
            string imagePath = imageEmployee.ImageLocation;

            byte[] image = null;
            if (imagePath != null)
            {
                image = File.ReadAllBytes(imagePath);
            }

            if (!string.IsNullOrEmpty(dni) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(phone) && !string.IsNullOrEmpty(position))
            {
                employeeSelected = new Employee(dni, name, email, phone, position, image);
            }

            if (employeeSelected == null || departmentSelected == null)
            {
                MessageBox.Show("Debes introducir todos los datos", "Guardado fallido", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            if (presenter.SaveEmployee(employeeSelected, departmentSelected))
            {
                MessageBox.Show($"Usuario con DNI: {dni} guardado correctamente.", "Guardado exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearVisualEmployeeData();
            }
            else
            {
                MessageBox.Show($"Usuario con DNI: {dni} ya existe", "Guardado fallido", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            employeeSelected = null;
        }

        private void OnClickUpdateEmployee(object? sender, EventArgs e)
        {
            string dni = dniTextBox.Text;
            string name = nameTextBox.Text;
            string email = emailTextBox.Text;
            string phone = phoneTextBox.Text;
            string position = positionTextBox.Text;
            string imagePath = imageEmployee.ImageLocation;
            byte[] image = null;
            if (imagePath != null)
            {
                image = File.ReadAllBytes(imagePath);
            }

            if (!string.IsNullOrEmpty(dni) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(phone) && !string.IsNullOrEmpty(position))
            {
                employeeSelected = new Employee(dni, name, email, phone, position, image);
            }

            if (employeeSelected == null || departmentSelected == null)
            {
                MessageBox.Show("Debes introducir todos los datos", "Actualizado fallido", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            if (presenter.UpdateEmployee(employeeSelected, departmentSelected))
            {
                MessageBox.Show($"Usuario con DNI: {dni} actualizado correctamente.", "Actualizado exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearVisualEmployeeData();
            }
            else
            {
                MessageBox.Show($"Usuario con DNI: {dni} no existe", "Actualizado fallido", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            employeeSelected = null;
        }

        private void OnClickDeleteEmployee(object? sender, EventArgs e)
        {
            string dni = dniTextBox.Text;
            string name = nameTextBox.Text;
            string email = emailTextBox.Text;
            string phone = phoneTextBox.Text;
            string position = positionTextBox.Text;
            string imagePath = imageEmployee.ImageLocation;
            byte[] image = null;
            if (imagePath != null)
            {
                image = File.ReadAllBytes(imagePath);
            }

            if (!string.IsNullOrEmpty(dni) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(phone) && !string.IsNullOrEmpty(position))
            {
                employeeSelected = new Employee(dni, name, email, phone, position, image);
            }

            if (employeeSelected == null && departmentSelected == null)
            {
                MessageBox.Show("Debes introducir todos los datos", "Eliminado fallido", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

            if (presenter.DeleteEmployee(employeeSelected, departmentSelected))
            {
                MessageBox.Show($"Usuario con DNI: {employeeSelected.DNI} eliminado correctamente.", "Eliminado exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearVisualEmployeeData();
            }
            employeeSelected = null;
        }

        private void OnClickDepartmentTable(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int selectedIndex = e.RowIndex;

                // Recogemos el Tag
                var tag = tableDepartments.Rows[selectedIndex].Tag;
                if (tag != null)
                {
                    tableEmployees.Rows.Clear();
                    ClearVisualEmployeeData();

                    tableEmployees.Rows.Clear();

                    departmentSelected = (Department)tag;

                    departmentTextBox.Text = departmentSelected.Name;

                    presenter.SetEmployeesToTable(departmentSelected);

                    tableEmployees.ClearSelection();
                }
            }
        }

        private void OnClickEmployeeTable(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtenemos el índice de la fila clicada
                int selectedIndex = e.RowIndex;

                // Recogemos el Tag
                var tag = tableEmployees.Rows[selectedIndex].Tag;
                if (tag != null)
                {
                    var employeeSelected = (Employee)tag;

                    byte[] imageBytes = employeeSelected.FileImage;
                    // Verificamos que el array de bytes no sea nulo y tenga contenido
                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        // Convertimos los bytes a una imagen
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            Image image = Image.FromStream(ms);

                            // Mostramos la imagen en el PictureBox
                            imageEmployee.Image = image;
                        }
                    }
                    else
                    {
                        imageEmployee.Image = Resource.DefaultImage;
                    }
                    dniTextBox.Text = employeeSelected.DNI;
                    nameTextBox.Text = employeeSelected.Name;
                    emailTextBox.Text = employeeSelected.Email;
                    phoneTextBox.Text = employeeSelected.Phone;
                    positionTextBox.Text = employeeSelected.Position;
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Desmarcar la selección predeterminada
            tableDepartments.ClearSelection();
            tableEmployees.ClearSelection();
        }

        private void ClearVisualEmployeeData()
        {
            imageEmployee.Image = null;
            dniTextBox.Text = "";
            nameTextBox.Text = "";
            emailTextBox.Text = "";
            phoneTextBox.Text = "";
            positionTextBox.Text = "";
        }

        private void OnFormPaint(object sender, PaintEventArgs e)
        {
            Color colorFondo = Color.FromArgb(245, 168, 108);
            SolidBrush brush = new SolidBrush(colorFondo);
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }

        public void SetPresenter(ContactsPresenter presenter)
        {
            this.presenter = presenter;
        }
    }
}

