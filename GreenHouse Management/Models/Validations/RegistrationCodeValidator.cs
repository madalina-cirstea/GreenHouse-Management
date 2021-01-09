using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace GreenHouse_Management.Models.Validations
{
    public class RegistrationCodeValidator : ValidationAttribute
    {
        private bool CheckProductKeyFromat(string productKey)
        {
            Regex rgx = new Regex(@"^[a-z]\d+-\d+$");
            return rgx.IsMatch(productKey);
        }

        private bool CheckProductKeyValidity(string productKey)
        {
            ApplicationDbContext ctx = new ApplicationDbContext();
            return ctx.Products.FirstOrDefault(p => p.ProductKey == productKey) != null;
        }

        private bool CheckProductKeyUniqueness(string productKey)
        {
            ApplicationDbContext ctx = new ApplicationDbContext();
            return ctx.RegisteredUsers.FirstOrDefault(user => user.RegistrationCode == productKey) == null;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var register = (RegisterViewModel)validationContext.ObjectInstance;
            if (register.RoleName.Equals("Customer"))
            {
                if (!CheckProductKeyFromat(register.RegistrationCode))
                    return new ValidationResult("Invalid product key code format!");

                if (!CheckProductKeyValidity(register.RegistrationCode))
                    return new ValidationResult("Invalid product key!");

                if (!CheckProductKeyUniqueness(register.RegistrationCode))
                    return new ValidationResult("Another product was already registered with the same product key!");

                return ValidationResult.Success;
            }
            else //if (register.RoleName.Equals("Admin"))
            {
                return ValidationResult.Success;
            }
        }

    }
}