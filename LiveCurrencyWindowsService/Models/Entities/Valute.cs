using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace LiveCurrencyWindowsService.Models.Entities
{
    [XmlRoot(ElementName = "Valute")]
    public class Valute
    {
        [XmlElement(ElementName = "Nominal")]
        public string Nominal { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "Value")]
        public string Value { get; set; }
        [XmlAttribute(AttributeName = "Code")]
        [Key]
        public string Code { get; set; }

        public int ValTypeId { get; set; }
    }
}
