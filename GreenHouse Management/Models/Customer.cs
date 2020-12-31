using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GreenHouse_Management.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
 
        [Required]
        [MinLength(5, ErrorMessage = "Customer name cannot be less than 5!"),
         MaxLength(20, ErrorMessage = "Customer name cannot be more than 20!")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Customer address cannot be less than 5!"),
         MaxLength(50, ErrorMessage = "Customer address cannot be more than 50!")]
        public string Address { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}