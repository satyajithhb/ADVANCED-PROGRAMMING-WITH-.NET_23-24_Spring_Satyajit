using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ValidationTask_Class3.Annotation
{
    public class validateID:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var id = value as string;

            if (id == null)
            {
                return new ValidationResult("ID must be a number.");
            }
            var pattern = @"^\d{2}-\d{5}-[1-3]$";

            if (!Regex.IsMatch(id, pattern))
            {
                return new ValidationResult("ID must be in XX-XXXXX-X format with specific digit ranges.");
            }

            return ValidationResult.Success;
        }
    }
}