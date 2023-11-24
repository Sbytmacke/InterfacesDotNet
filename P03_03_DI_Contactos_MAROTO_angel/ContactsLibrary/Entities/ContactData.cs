using System.Xml.Serialization;

namespace ContactsLibrary.Entities;


[Serializable]
[XmlRoot("ContactsData")]
public class ContactsData
{
    [XmlElement("Department")]
    public List<DepartmentEntity> Departments { get; set; }

    public ContactsData()
    {
        Departments = new List<DepartmentEntity>();
    }
}
