using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ValidationTask_Class3.Annotation;


namespace ValidationTask_Class3.Models
{
    public class Person
    {
        [Required(ErrorMessage = "Please provide your name.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name must contain only alphabets and spaces.")]
        [StringLength(100, ErrorMessage = "Name must be less than 100 character.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please provide your username.")]
        [validateUsername]
        public string Uname { get; set; }

        [Required(ErrorMessage = "Please provide your ID number in XX-XXXXX-X format.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Id format should be XX-XXXXX-X]")]
        [validateID]
        public string Id { get; set; }

        [Required(ErrorMessage = "Please use your institutional email.")]
        [validateEmail]
        public string Email { get; set; }
    }
}