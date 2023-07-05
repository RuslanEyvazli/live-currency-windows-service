using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace LiveCurrencyWindowsService.Models.Entities
{
    [XmlRoot(ElementName = "ValCurs")]
    public class ValCurs
    {
        [Key]
        public int Id { get; set; }
        [XmlElement(ElementName = "ValType")]
        public List<ValType> ValType { get; set; }
        [XmlAttribute(AttributeName = "Date")]
        public string Date { get; set; }
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "Description")]
        public string Description { get; set; }
    }

}
