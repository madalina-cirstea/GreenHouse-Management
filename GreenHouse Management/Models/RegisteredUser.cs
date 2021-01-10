using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GreenHouse_Management.Models
{
    public class RegisteredUser
    {
        public int RegisteredUserId { get; set; }

        [Required]
        public string UserId { get; set; } 

        [Required]
        public string Email { get; set; }

        [Required]
        public string RoleName { get; set; }

        [Required]
        public string RegistrationCode { get; set; }
    }
}