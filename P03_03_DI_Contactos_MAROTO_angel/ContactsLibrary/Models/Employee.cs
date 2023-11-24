namespace Models;
public class Employee
{
    public string DNI { get; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Position { get; set; }
    public byte[] FileImage { get; set; }

    public Employee(string dni, string name, string email, string phone, string position, byte[] fileImage)
    {
        DNI = dni;
        Name = name;
        Email = email;
        Phone = phone;
        Position = position;
        FileImage = fileImage;
    }
}

