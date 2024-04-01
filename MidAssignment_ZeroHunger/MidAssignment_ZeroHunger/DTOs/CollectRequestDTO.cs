using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MidAssignment_ZeroHunger.DTOs
{
    public class CollectRequestDTO
    {
        public int CollectReqId { get; set; }
        public int RestaurantsId { get; set; }
        [Required(ErrorMessage = "Please provide what kind od Food.")]
        public string Food_Name { get; set; }
        [Required(ErrorMessage = "Please provide Food details.")]
        public string Food_Description { get; set; }
        [Required(ErrorMessage = "Please provide Food Quantity.")]
        public int Food_Quantity { get; set; }
        [Required(ErrorMessage = "Please provide maximum preservation time in hours.")]
        public int Preservation_Time { get; set; }
        public System.DateTime Request_Time { get; set; }
        public string Employee_Status { get; set; }
        public Nullable<int> Employee_id { get; set; }
        public string Distribution_Status { get; set; }
        public int NgoId { get; set; }
    }
}