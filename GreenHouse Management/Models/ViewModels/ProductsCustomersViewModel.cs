using GreenHouse_Management.Models.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenHouse_Management.Models.ViewModels
{
    public class ProductsCustomersViewModel
    {
        [Required]
        public List<Product> ProductsList { get; set; }

        [Required]
        public List<Customer> CustomersList { get; set; }
    }
}