using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace MidAssignment_ZeroHunger.Annotations
{
    public class validateUsername: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var username = value as string;

            if (username == null)
            {
                return new ValidationResult("Username can't be null.");
            }

            var pattern = @"^[^\s]{1,10}$";

            if (!Regex.IsMatch(username, pattern))
            {
                return new ValidationResult("Username can only contain alphabets, numbers, and special characters," +
                    "it must not exceed 10 characters.Also space is not allowed.");
            }

            return ValidationResult.Success;
        }
    }
}