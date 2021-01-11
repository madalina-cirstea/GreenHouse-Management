using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenHouse_Management.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Product name cannot be less than 5!"),
         MaxLength(20, ErrorMessage = "Product name cannot be more than 20!")]
        public string Name { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Product description cannot be less than 10!"),
         MaxLength(50, ErrorMessage = "Product description cannot be more than 50!")]
        public string Description { get; set; }

        [Required]
        [RegularExpression(@"^[a-z]\d+-\d+$", ErrorMessage = "Invalid key product format!")]
        public string ProductKey { get; set; }

        [Required]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}