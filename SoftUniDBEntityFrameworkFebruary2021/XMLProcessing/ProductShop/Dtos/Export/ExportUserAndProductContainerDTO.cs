using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("Users")]
    public class ExportUserAndProductContainerDTO
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlElement("users")]
        public List<ExportUserAndProductsDTO> Users { get; set; }
    }
}
