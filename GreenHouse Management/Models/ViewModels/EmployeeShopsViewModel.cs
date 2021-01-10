using GreenHouse_Management.Models.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenHouse_Management.Models.ViewModels
{
    public class EmployeeShopsViewModel
    {
        [Required]
        [MaxLength(20, ErrorMessage = "Employee name cannot be more than 20!")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[a-z]{1}\d{4}$", ErrorMessage = "EIN must have a valid format!")]
        public string EIN { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Employee address cannot be more than 50!")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Shop")]
        public string ShopId { get; set; }

        public IEnumerable<SelectListItem> ShopsList { get; set; }
    }
}