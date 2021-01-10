using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GreenHouse_Management.Models
{
    public class Shop
    {
        public int ShopId { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Shop name cannot be more than 15!")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]{2}\d{4}$", ErrorMessage = "BIN must have a valid format!")]
        public string BIN { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Shop address cannot be more than 50!")]
        public string Address { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}