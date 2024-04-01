using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MidAssignment_ZeroHunger.Annotations;

namespace MidAssignment_ZeroHunger.DTOs
{
    public class EmployeesDTO
    {
        public int EmpId { get; set; }
        [Required(ErrorMessage = "Please provide your Name.")]
        public string EmpName { get; set; }
        [Required(ErrorMessage = "Please provide your Address.")]
        public string EmpAddress { get; set; }
        [Required(ErrorMessage = "Please provide your Phone number.")]
        public string EmpContact { get; set; }
        [Required(ErrorMessage = "Please provide your username.")]
        [validateUsername]
        public string EmpUser { get; set; }
        [Required(ErrorMessage = "Please provide your password.")]
        [validatePassword]
        public string EmpPass { get; set; }
        public int NgoId { get; set; }
    }
}