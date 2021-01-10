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
        private bool CheckAdminKeyFromat(string adminKey)
        {
            Regex rgx = new Regex(@"^[A-Z]{2}\d{4}-[a-z]{1}\d{4}$");
            return rgx.IsMatch(adminKey);
        }

        private bool CheckAdminKeyValidity(string adminKey)
        {
            string BIN = adminKey.Substring(0, 6);
            string EIN = adminKey.Substring(7, 5);

            ApplicationDbContext ctx = new ApplicationDbContext();
            Employee emp = ctx.Employees.FirstOrDefault(e => e.EIN.Equals(EIN));
            if (emp != null)
            {
                Shop shop = ctx.Shops.FirstOrDefault(s => s.ShopId == emp.ShopId);
                if (shop != null)
                {
                    if (shop.BIN.Equals(BIN))
                        return true;
                }
            }

            return false;
        }

        private bool CheckAdminKeyUniqueness(string adminKey)
        {
            ApplicationDbContext ctx = new ApplicationDbContext();
            return ctx.RegisteredUsers.FirstOrDefault(user => user.RegistrationCode == adminKey) == null;
        }

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
                if (!CheckAdminKeyFromat(register.RegistrationCode))
                    return new ValidationResult("Invalid admin key code format!");

                if (!CheckAdminKeyValidity(register.RegistrationCode))
                    return new ValidationResult("Invalid admin key!");

                if (!CheckAdminKeyUniqueness(register.RegistrationCode))
                    return new ValidationResult("Another admin was already registered with the same identification key!");

                return ValidationResult.Success;
            }
        }

    }
}