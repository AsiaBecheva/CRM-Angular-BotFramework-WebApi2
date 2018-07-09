using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRMSystem.Models
{
    [Serializable]
    public class Customer
    {
        public Customer()
        {
            this.AddedOn = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Company { get; set; }

        [Required]
        [MaxLength(100)]
        public string Username { get; set; }

        [MaxLength(40)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        public Status Status { get; set; }


        public DateTime AddedOn { get; set; }

        public List<CustomerProduct> SalledProducts { get; set; } = new List<CustomerProduct>();
    }
}
