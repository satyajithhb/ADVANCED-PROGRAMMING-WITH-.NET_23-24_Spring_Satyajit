using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MidAssignment_ZeroHunger.Annotations;

namespace MidAssignment_ZeroHunger.DTOs
{
    public class RestaurantsDTO
    {
        public int ResId { get; set; }
        [Required(ErrorMessage = "Please provide your Restaurant's name.")]
        public string ResName { get; set; }
        [Required(ErrorMessage = "Please provide your Restaurant's address.")]
        public string ResAddress { get; set; }
        [Required(ErrorMessage = "Please provide your Restaurant's contact number.")]
        public string ResContact { get; set; }
        [Required(ErrorMessage = "Please provide your Restaurant's username.")]
        [validateUsername]
        public string ResUser { get; set; }
        [Required(ErrorMessage = "Please provide passwords.")]
        [validatePassword]
        public string ResPass { get; set; }
        public int NgoId { get; set; }
    }
}