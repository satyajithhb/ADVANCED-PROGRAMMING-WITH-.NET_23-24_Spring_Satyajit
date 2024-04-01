using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace MidAssignment_ZeroHunger.Annotations
{
    public class validatePassword: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var password = value as string;

            if (password == null)
            {
                return new ValidationResult("Password can't be null.");
            }

            var pattern = @"^[^\s]{1,10}$";

            if (!Regex.IsMatch(password, pattern))
            {
                return new ValidationResult("Password can only contain alphabets, numbers, and special characters," +
                    "it must not exceed 10 characters.Also space is not allowed.");
            }

            return ValidationResult.Success;
        }
    }
}