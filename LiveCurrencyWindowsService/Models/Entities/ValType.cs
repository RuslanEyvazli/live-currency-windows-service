using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace LiveCurrencyWindowsService.Models.Entities
{
    [XmlRoot(ElementName = "ValType")]
    public class ValType
    {
        [Key]
        public int Id { get; set; }
        [XmlElement(ElementName = "Valute")]
        
        [XmlAttribute(AttributeName = "Type")]
        public string Type { get; set; }

        public virtual ICollection<Valute> Valutes { get; set; }
        public int ValCursId { get; set; }
    }
}
