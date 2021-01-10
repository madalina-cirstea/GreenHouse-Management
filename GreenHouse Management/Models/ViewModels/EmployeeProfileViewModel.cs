using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GreenHouse_Management.Models.ViewModels
{
    public class EmployeeProfileViewModel
    {
        [Required]
        public Employee Employee { get; set; }

        [Required]
        public Shop Shop { get; set; }
    }
}