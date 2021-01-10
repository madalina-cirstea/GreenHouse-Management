using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GreenHouse_Management.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

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
        public int ShopId { get; set; }
        public virtual Shop Shop { get; set; }
    }
}