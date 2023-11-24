namespace P03_03_DI_Contactos_MAROTO_angel.Presenters;

using ContactsLibrary.Entities;
using ContactsLibrary.Repositories;
using Models;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;

public class ContactsPresenter
{
    private ContactsView contactsView;
    private DepartmentRepositoryImpl departmentRepositoryImpl;
    private EmployeeRepositoryImpl employeeRepositoryImpl;

    public ContactsPresenter(ContactsView contactsView, DepartmentRepositoryImpl departmentRepositoryImpl, EmployeeRepositoryImpl employeeRepositoryImpl)
    {
        this.contactsView = contactsView;
        this.departmentRepositoryImpl = departmentRepositoryImpl;
        this.employeeRepositoryImpl = employeeRepositoryImpl;

        AttachEventHandlers();
    }

    private void AttachEventHandlers()
    {
        contactsView.NewFile += NewFile;
        contactsView.OpenFile += OpenFile;
        contactsView.SaveFile += SaveMenuItem;
        contactsView.SaveAsFile += SaveAsMenuItem;
    }

    public void InitDataToTest()
    {
        Department departamento1 = new Department("Recursos Humanos");
        Department departamento2 = new Department("Tecnologías de la Información");
        Department departamento3 = new Department("Finanzas");

        Bitmap myBitmap = new Bitmap(Resource.DefaultImage);
        byte[] bytesImagen;

        using (MemoryStream stream = new MemoryStream())
        {
            myBitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            bytesImagen = stream.ToArray();
        }

        Employee empleado1 = new Employee("12345678A", "Juan Gómez", "juan.gomez@example.com", "612345678", "Junior", bytesImagen);
        Employee empleado2 = new Employee("98765432B", "Ana Martínez", "ana.martinez@example.com", "654987321", "Junior", bytesImagen);
        Employee empleado3 = new Employee("11223344C", "Carlos Sánchez", "carlos.sanchez@example.com", "611223344", "Junior", bytesImagen);
        Employee empleado4 = new Employee("44556677D", "Elena López", "elena.lopez@example.com", "444555666", "Senior", bytesImagen);
        Employee empleado5 = new Employee("77889999E", "Luis Vega", "luis.vega@example.com", "777888999", "Middle", bytesImagen);
        Employee empleado6 = new Employee("33399911F", "María Díaz", "maria.diaz@example.com", "333999111", "Middle", bytesImagen);
        Employee empleado7 = new Employee("55666777G", "Pablo Rodríguez", "pablo.rodriguez@example.com", "555666777", "Senior", bytesImagen);
        Employee empleado8 = new Employee("99111333H", "Isabel Fernández", "isabel.fernandez@example.com", "999111333", "Middle", bytesImagen);

        departamento1.ListEmployees.Add(empleado1);
        departamento1.ListEmployees.Add(empleado2);
        departamento1.ListEmployees.Add(empleado3);
        departamento2.ListEmployees.Add(empleado4);
        departamento2.ListEmployees.Add(empleado5);
        departamento3.ListEmployees.Add(empleado6);
        departamento3.ListEmployees.Add(empleado7);
        departamento3.ListEmployees.Add(empleado8);

        departmentRepositoryImpl.AddItem(departamento1);
        departmentRepositoryImpl.AddItem(departamento2);
        departmentRepositoryImpl.AddItem(departamento3);

        employeeRepositoryImpl.AddItem(empleado1);
        employeeRepositoryImpl.AddItem(empleado2);
        employeeRepositoryImpl.AddItem(empleado3);
        employeeRepositoryImpl.AddItem(empleado4);
        employeeRepositoryImpl.AddItem(empleado5);
        employeeRepositoryImpl.AddItem(empleado6);
        employeeRepositoryImpl.AddItem(empleado7);
        employeeRepositoryImpl.AddItem(empleado8);
    }

    public void SetDepartmentsToTable()
    {
        contactsView.tableDepartments.Rows.Clear();

        List<Department> departments = departmentRepositoryImpl.GetItems();

        if (departments.Count > 0)
        {
            foreach (var departmentItem in departments)
            {
                contactsView.tableDepartments.Rows.Add(departmentItem.Name);
                // Recogemos el índice de la ultima fila añadida
                int lastRowIndex = contactsView.tableDepartments.Rows.Count - 1;
                contactsView.tableDepartments.Rows[lastRowIndex].Tag = departmentItem;
            }
        }
    }

    internal void SetEmployeesToTable(Department departmentSelected)
    {
        contactsView.tableEmployees.Rows.Clear();

        List<Employee> employees = departmentRepositoryImpl.GetItem(departmentSelected.Name).ListEmployees;

        if (employees.Count > 0)
        {
            foreach (var employeeItem in employees)
            {
                contactsView.tableEmployees.Rows.Add(employeeItem.Name);
                // Recogemos el índice de la ultima fila añadida
                int lastRowIndex = contactsView.tableEmployees.Rows.Count - 1;
                contactsView.tableEmployees.Rows[lastRowIndex].Tag = employeeItem;
            }
        }
    }

    internal Boolean DeleteEmployee(Employee employee, Department department)
    {
        if (employeeRepositoryImpl.DeleteItem(employee.DNI))
        {
            var departmentToUpdate = departmentRepositoryImpl.GetItem(department.Name);
            var originalEmployeeToUpdate = departmentToUpdate.ListEmployees.FirstOrDefault(e => e.DNI == employee.DNI);

            if (originalEmployeeToUpdate != null)
            {
                departmentToUpdate.ListEmployees.Remove(originalEmployeeToUpdate);
                SetEmployeesToTable(departmentToUpdate);
            }
        }
        else
        {
            return false;
        }
        return true;
    }

    internal Boolean SaveEmployee(Employee employee, Department department)
    {
        if (employeeRepositoryImpl.GetItem(employee.DNI) != null)
        {
            return false;
        }

        var newEmployee = employeeRepositoryImpl.AddItem(employee);

        if (newEmployee == null)
        {
            return false;
        }

        var departmentToUpdate = departmentRepositoryImpl.GetItem(department.Name);
        departmentToUpdate.ListEmployees.Add(newEmployee);
        SetEmployeesToTable(departmentToUpdate);

        return true;
    }

    internal Form InitContactsView()
    {
        return contactsView;
    }

    internal bool UpdateEmployee(Employee employee, Department department)
    {
        var updatedEmployee = employeeRepositoryImpl.UpdateItem(employee);

        if (updatedEmployee == null)
        {
            return false;
        }

        var departmentToUpdate = departmentRepositoryImpl.GetItem(department.Name);
        var originalEmployeeToUpdate = departmentToUpdate.ListEmployees.FirstOrDefault(e => e.DNI == employee.DNI);

        if (originalEmployeeToUpdate != null)
        {
            departmentToUpdate.ListEmployees.Remove(originalEmployeeToUpdate);
            departmentToUpdate.ListEmployees.Add(updatedEmployee);
            SetEmployeesToTable(departmentToUpdate);
        }

        return true;
    }

    private void NewFile(object sender, EventArgs e)
    {
        DialogResult result = MessageBox.Show("¿Desea guardar el archivo actual?", "Guardar archivo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            if (contactsView.CurrentFilePath == null)
            {
                SaveAsMenuItem(sender, e);
            }
            else
            {
                SaveMenuItem(sender, e);
            }
        }
        contactsView.CurrentFilePath = null;

        // Limpiamos los datos en memoria
        departmentRepositoryImpl.ClearItems();
        employeeRepositoryImpl.ClearItems();

        SetDepartmentsToTable();
    }

    private void SaveMenuItem(object sender, EventArgs e)
    {
        // Verificamos si se ha guardado el archivo anteriormente
        if (contactsView.CurrentFilePath == null)
        {
            SaveAsMenuItem(sender, e);
        }
        else
        {
            // Si ya se ha guardado, sobrescribimos el archivo
            try
            {
                SaveSerializeItem();
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
        saveFileDialog.Filter = "Archivos de texto (*.xml)|*.xml|Todos los archivos (*.*)|*.*";
        saveFileDialog.Title = "Guardar Como";

        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            string filePath = saveFileDialog.FileName;

            try
            {
                contactsView.CurrentFilePath = filePath;
                SaveSerializeItem();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void SaveSerializeItem()
    {
        // Instancia serializable
        ContactsData data = new ContactsData();

        foreach (Department department in departmentRepositoryImpl.GetItems())
        {
            List<EmployeeEntity> employeesEntities = new List<EmployeeEntity>();
            foreach (Employee employee in department.ListEmployees)
            {
                employeesEntities.Add(new EmployeeEntity(employee.DNI, employee.Name, employee.Email, employee.Phone, employee.Position, employee.FileImage));
            }

            DepartmentEntity departmentEntity = new DepartmentEntity(department.Name, employeesEntities);

            data.Departments.Add(departmentEntity);
        }

        // Utilizo el serializador XML, ya que el binario me da aviso de obsoleto
        XmlSerializer serializer = new XmlSerializer(typeof(ContactsData));

        using (StreamWriter sw = new StreamWriter(contactsView.CurrentFilePath))
        {
            serializer.Serialize(sw, data);
        }

        MessageBox.Show("Cambios guardados correctamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void OpenFile(object sender, EventArgs e)
    {

        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Archivos XML (*.xml)|*.xml|Todos los archivos (*.*)|*.*";
        openFileDialog.Title = "Abrir";

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {

            string filePath = openFileDialog.FileName;

            contactsView.CurrentFilePath = filePath;

            List<Department> newDepartments = new List<Department>();
            List<Employee> newEmployees = new List<Employee>();
            try
            {
                ContactsData data = XmlSerializationHelper.DeserializeFromFile(filePath);

                // Mapeamos las entities a las clases de dominio
                foreach (DepartmentEntity departmentEntity in data.Departments)
                {
                    Department department = new Department(departmentEntity.Name);

                    foreach (EmployeeEntity employeeEntity in departmentEntity.Employees)
                    {
                        Employee employee = new Employee(
                            employeeEntity.DNI,
                            employeeEntity.Name,
                            employeeEntity.Email,
                            employeeEntity.Phone,
                            employeeEntity.Position,
                            employeeEntity.FileImage
                        );
                        newEmployees.Add(employee);
                        department.ListEmployees.Add(employee);
                    }
                    newDepartments.Add(department);
                }

                MessageBox.Show("Archivo cargado correctamente.", "Abrir", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Limpiamos los datos en memoria
            departmentRepositoryImpl.ClearItems();
            employeeRepositoryImpl.ClearItems();

            // Utilizamos los nuevos datos
            foreach (Department department in newDepartments)
            {
                departmentRepositoryImpl.AddItem(department);
            }
            foreach (Employee employee in newEmployees)
            {
                employeeRepositoryImpl.AddItem(employee);
            }

            SetDepartmentsToTable();
        }
    }

    public static class XmlSerializationHelper
    {
        public static void SerializeToFile(string filePath, ContactsData data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ContactsData));
            StreamWriter sw = new StreamWriter(filePath);
            serializer.Serialize(sw, data);
            sw.Close();
        }

        public static ContactsData DeserializeFromFile(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ContactsData));
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                return (ContactsData)serializer.Deserialize(fileStream);
            }
        }
    }
}

