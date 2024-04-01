using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MidAssignment_ZeroHunger.DTOs;

namespace MidAssignment_ZeroHunger.Models
{
    public class AssignEmployeeViewModel
    {
        public IEnumerable<CollectRequestDTO> UnassignedRequests { get; set; }
        public List<SelectListItem> AvailableEmployees { get; set; }
        public int SelectedRequest { get; set; }
        public int SelectedEmployee { get; set; }
    }

}