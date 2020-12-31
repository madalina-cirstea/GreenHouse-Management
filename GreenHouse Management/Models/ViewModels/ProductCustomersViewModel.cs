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
        public Product Product { get; set; }
        
        //[Required]
        public IEnumerable<SelectListItem> CustomersList { get; set; }
    }
}