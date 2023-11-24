using System.Xml.Serialization;

namespace ContactsLibrary.Entities;

[Serializable]
[XmlRoot("Department")]
public class DepartmentEntity
{
    [XmlElement("Name")]
    public string Name { get; set; }

    [XmlArray("Employees")]
    [XmlArrayItem("Employee")]
    public List<EmployeeEntity> Employees { get; set; }

    public DepartmentEntity() { }

    public DepartmentEntity(string name, List<EmployeeEntity> employees)
    {
        this.Name = name;
        this.Employees = employees;
    }
}

