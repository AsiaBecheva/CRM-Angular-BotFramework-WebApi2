using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRMSystem.Models;

namespace CRMSystem.Client.DTOModels
{
    public class ProductDTO
    {
        public string Name { get; set; }
        
        public string Info { get; set; }
        
        public decimal Price { get; set; }

        public ICollection<CustomerProduct> SalledProducts { get; set; }
    }
}
