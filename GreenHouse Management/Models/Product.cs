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
        public string Name { get; set; }

        public string ProductKey { get; set; }

        [Required]
        public string Status { get; set; }

        // FK
        [Required]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public Product() { }

        // copy constructor 
        public Product(Product p)
        {
            ProductId = p.ProductId;
            Name = p.Name;
            Status = p.Status;
            CustomerId = p.CustomerId;
        }
    }
}