using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MidAssignment_ZeroHunger.Annotations;

namespace MidAssignment_ZeroHunger.DTOs
{
    public class NgoDTO
    {
        public int NgoID { get; set; }
        public string NgoName { get; set; }
        public string NgoAddress { get; set; }
        public string NgoContact { get; set; }
        [Required(ErrorMessage = "Please provide NGO username.")]
        [validateUsername]
        public string NgoUser { get; set; }
        [Required(ErrorMessage = "Please provide NGO password.")]
        [validatePassword]
        public string NgoPass { get; set; }
    }
}