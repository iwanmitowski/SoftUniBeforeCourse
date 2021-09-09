using Newtonsoft.Json;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.DTOs
{
    class SuccessfullySoldProductsDTO
    {
        public SuccessfullySoldProductsDTO()
        {
            ProductsSold = new List<SuccessfullySoldProductsBuyerDTO>();
        }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("soldProducts")]
        public IEnumerable<SuccessfullySoldProductsBuyerDTO> ProductsSold { get; set; }
    }
}
