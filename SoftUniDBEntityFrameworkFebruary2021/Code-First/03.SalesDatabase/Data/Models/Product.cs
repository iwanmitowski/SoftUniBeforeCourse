using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.SalesDatabase.Data.Models
{
    class Product
    {
        public int ProductId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public double Quantity { get; set; }

        public decimal Price { get; set; }

        [Required]
        [DefaultValue("No description")]
        [MaxLength(250)]
        public string Description { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
