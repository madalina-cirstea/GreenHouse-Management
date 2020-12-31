using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace GreenHouse_Management.Models.Validations
{
    public class ProductKeyValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var register = (RegisterViewModel)validationContext.ObjectInstance;
            string productKey = "comment"; //register.ProductKey;

            // format check
            Regex rgx = new Regex(@"^[a-z]\d{4}-\d{4}$");
            if (!rgx.IsMatch(productKey))
                return new ValidationResult("Invalid key product format! eg: G1234-1234");

            // validity check


            // uniqueness check
            // if (!)


             return ValidationResult.Success;
        }

    }
}