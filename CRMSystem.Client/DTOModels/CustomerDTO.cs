using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CRMSystem.Models;

namespace CRMSystem.DTOModels.Models
{
    [Serializable]
    public class CustomerDTO
    {
        public string Company { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Address { get; set; }

        public Status Status { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public List<CustomerProduct> SalledProducts { get; set; }
    }
}
