using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MidAssignment_ZeroHunger.DTOs;
using MidAssignment_ZeroHunger.EF;
using MidAssignment_ZeroHunger.Models;

namespace MidAssignment_ZeroHunger.Controllers
{
    public class NGOController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(NgoDTO ngo)
        {
            var db = new MidAssignmentEntities();
            var loggedInNGO = db.NGOes.FirstOrDefault(selectngo => selectngo.NgoUser == ngo.NgoUser && selectngo.NgoPass == ngo.NgoPass);
            if (loggedInNGO != null)
            {
                Session["LoggedInNGOName"] = loggedInNGO.NgoName;
                return RedirectToAction("Dashboard");
            }
            ModelState.AddModelError("", "Invalid username or password");
            return View(ngo);
        }

        public ActionResult Dashboard()
        {
            var db = new MidAssignmentEntities();
            var loggedInNGOName = (string)Session["LoggedInNGOName"];

            var allNGOs = db.NGOes.ToList().Select(n => new NgoDTO
            {
                NgoID = n.NgoID,
                NgoName = n.NgoName,
                NgoAddress = n.NgoAddress,
                NgoContact = n.NgoContact,
                NgoUser = n.NgoUser,
                NgoPass = n.NgoPass
            });

            var allEmployees = db.Employees.ToList().Select(e => new EmployeesDTO
            {
                EmpId = e.EmpId,
                EmpName = e.EmpName,
                EmpAddress = e.EmpAddress,
                EmpContact = e.EmpContact,
                EmpUser = e.EmpUser,
                EmpPass = e.EmpPass,
                NgoId = e.NgoId
            });

            var viewModel = Tuple.Create(allNGOs, allEmployees);

            return View(viewModel);
        }



        [HttpPost]
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Login");
        }
        public ActionResult AssignEmployee()
        {
            var db = new MidAssignmentEntities();

            var loggedInNGOName = (string)Session["LoggedInNGOName"];

            var unassignedRequests = db.Collect_Requests
                                        .Where(cr => cr.Employee_Status == "Unassigned")
                                        .ToList()
                                        .Select(cr => new CollectRequestDTO
                                        {
                                            CollectReqId = cr.CollectReqId
                                        });

            var availableEmployees = db.Employees
                                        .Where(e => e.NGO.NgoName == loggedInNGOName)
                                        .Select(e => new SelectListItem
                                        {
                                            Value = e.EmpId.ToString(),
                                            Text = e.EmpName
                                        })
                                        .ToList();

            var viewModel = new AssignEmployeeViewModel
            {
                UnassignedRequests = unassignedRequests,
                AvailableEmployees = availableEmployees,
                SelectedEmployee = 1
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult ProcessAssignEmployee(AssignEmployeeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var db = new MidAssignmentEntities();
                var collectRequest = db.Collect_Requests.Find(viewModel.SelectedRequest);

                if (collectRequest != null)
                {
                    collectRequest.Employee_id = viewModel.SelectedEmployee;
                    collectRequest.Employee_Status = "Assigned";
                    db.SaveChanges();
                }
                TempData["Msg"] = "Employee Successfully Assigned";
                return RedirectToAction("ShowUnassignedReq");
            }
            return View("AssignEmployee", viewModel);
        }

        public static List<CollectRequestDTO> Convert(List<Collect_Request> data)
        {
            var list = new List<CollectRequestDTO>();
            foreach (var item in data)
            {
                list.Add(Convert(item));
            }
            return list;
        }
        public static CollectRequestDTO Convert(Collect_Request cr)
        {
            return new CollectRequestDTO()
            {
                CollectReqId = cr.CollectReqId,
                RestaurantsId = cr.RestaurantsId,
                Food_Name = cr.Food_Name,
                Food_Description = cr.Food_Description,
                Food_Quantity = cr.Food_Quantity,
                Preservation_Time = cr.Preservation_Time,
                Request_Time = cr.Request_Time,
                Employee_Status = cr.Employee_Status,
                Employee_id = cr.Employee_id,
                Distribution_Status = cr.Distribution_Status
            };
        }

        public ActionResult ShowAllCollectionReq()
        {
            var db = new MidAssignmentEntities();
            var collectionRequests = db.Collect_Requests.ToList();
            return View(Convert(collectionRequests));
        }
        public ActionResult ShowUnassignedReq()
        {
            var db = new MidAssignmentEntities();
            var unassignedRequests = db.Collect_Requests.Where(cr => cr.Employee_Status == "Unassigned").ToList();
            return View(Convert(unassignedRequests));
        }

    }
}