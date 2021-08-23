using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.SalesDatabase.Data.Models
{
    class Store
    {
        public int StoreId { get; set; }

        [Required]
        [MaxLength(80)]
        public string Name { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
