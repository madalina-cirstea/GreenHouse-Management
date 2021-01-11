using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GreenHouse_Management.Models
{
    public class Greenhouse
    {
        public int GreenhouseId { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Greenhouse name cannot be more than 15!")]
        public string Name { get; set; }

        [Required]
        public string ProductKey { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Greenhouse location cannot be more than 50!")]
        public string Location { get; set; }

        [Required]
        [Range(1, 13, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Display(Name = "Hardiness")]
        public int HardinessZone { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RegistrationDate { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }
    }
}