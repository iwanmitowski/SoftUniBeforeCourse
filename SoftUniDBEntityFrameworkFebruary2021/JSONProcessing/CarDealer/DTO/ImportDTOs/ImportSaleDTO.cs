using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DTO.ImportDTOs
{
    class ImportSaleDTO
    {
        public decimal Discount { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
    }
}
