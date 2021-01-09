using GreenHouse_Management.Models.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenHouse_Management.Models.ViewModels
{
    public class ProductCustomersViewModel
    {
        [Required]
        [MinLength(5, ErrorMessage = "Product name cannot be less than 5!"),
         MaxLength(20, ErrorMessage = "Product name cannot be more than 20!")]
        public string Name { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Product name cannot be less than 10!"),
         MaxLength(50, ErrorMessage = "Product name cannot be more than 50!")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Customer")]
        public string CustomerId { get; set; }

        public IEnumerable<SelectListItem> CustomersList { get; set; }
    }
}