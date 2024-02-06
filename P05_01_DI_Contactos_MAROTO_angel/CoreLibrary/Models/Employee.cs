namespace CoreLibrary.Models;

public class Employee
{
    public string Dni { get; set; }
    public string DepartmentName { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Position { get; set; }
    public byte[]? Image { get; set; }
    public Department Department { get; set; }  // Relación con el objeto para EntityFramework

    public Employee(string dni, string departmentName, string name, string email, string phone, string position, byte[]? image)
    {
        Dni = dni;
        DepartmentName = departmentName;
        Name = name;
        Email = email;
        Phone = phone;
        Position = position;
        Image = image;
    }

    public override string ToString()
    {
        return $"DNI: {Dni}, Name: {Name}, Email: {Email}, Phone: {Phone}, Position: {Position}";
    }
}

