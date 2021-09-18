﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("SoldProducts")]
    public class ExportProductDTO
    {
        [XmlElement("count")]
        public int Count => SoldProducts.Count();

        [XmlArray("products")]
        public List<ExportSoldProductDTO> SoldProducts { get; set; }
    }
}
