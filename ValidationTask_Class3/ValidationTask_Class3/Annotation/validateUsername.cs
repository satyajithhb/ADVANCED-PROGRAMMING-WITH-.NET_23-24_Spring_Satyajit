using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ValidationTask_Class3.Annotation
{
    public class validateUsername:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var username = value as string;

            if (username == null)
            {
                return new ValidationResult("Username can't be null.");
            }

            // Regular expression pattern for validating the username format
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