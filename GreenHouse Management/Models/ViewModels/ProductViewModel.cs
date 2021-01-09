using GreenHouse_Management.Models.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenHouse_Management.Models.ViewModels
{
    public class ProductViewModel
    {
        [Required]
        public List<Product> ProductsList { get; set; }

        [Required]
        public bool AllowAddAction { get; set; }
    }
}