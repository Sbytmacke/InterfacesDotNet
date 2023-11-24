using System.Xml.Serialization;

namespace ContactsLibrary.Entities
{
    [Serializable]
    [XmlRoot("Employee")]
    public class EmployeeEntity
    {
        [XmlElement("DNI")]
        public string DNI { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Email")]
        public string Email { get; set; }

        [XmlElement("Phone")]
        public string Phone { get; set; }

        [XmlElement("Position")]
        public string Position { get; set; }

        [XmlElement("FileImage")]
        public byte[] FileImage { get; set; }

        public EmployeeEntity() { }

        public EmployeeEntity(string dni, string name, string email, string phone, string position, byte[] fileImage)
        {
            this.DNI = dni;
            this.Name = name;
            this.Email = email;
            this.Phone = phone;
            this.Position = position;
            this.FileImage = fileImage;
        }
    }
}
