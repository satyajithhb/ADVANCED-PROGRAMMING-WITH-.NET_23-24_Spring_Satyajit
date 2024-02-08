using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using ValidationTask_Class3.Models;

namespace ValidationTask_Class3.Annotation
{
    public class validateEmail:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var id = (validationContext.ObjectInstance as Person)?.Id;
            var email = value as string;

            if (id == null || email == null)
            {
                return new ValidationResult("ID and Email can't be null.");
            }

            // Regular expression pattern for validating the ID format
            var idPattern = @"^\d{2}-\d{5}-[1-3]$";
            var emailPattern = $@"^{Regex.Escape(id)}@student.aiub.edu$";

            if (!Regex.IsMatch(id, idPattern))
            {
                return new ValidationResult("ID must be in XX-XXXXX-X format with specific digit ranges.");
            }

            if (!Regex.IsMatch(email, emailPattern))
            {
                return new ValidationResult("Email must be in ID@student.aiub.edu format.");
            }

            return ValidationResult.Success;
        }
    }
}