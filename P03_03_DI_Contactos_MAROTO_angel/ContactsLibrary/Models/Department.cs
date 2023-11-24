namespace Models;
public class Department
{

    public string Name { get; set; }
    public List<Employee> ListEmployees { get; set; } = new List<Employee>();

    public Department(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return $"Name: {Name}";
    }
}
