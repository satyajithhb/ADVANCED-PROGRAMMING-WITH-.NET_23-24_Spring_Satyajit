using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using System.Web.Mvc;
using MidAssignment_ZeroHunger.DTOs;
using MidAssignment_ZeroHunger.EF;

namespace MidAssignment_ZeroHunger.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MidAssignmentEntities _db;
        private readonly IMapper _mapper;

        public EmployeesController()
        {
            _db = new MidAssignmentEntities();
            _mapper = AutoMapperConfig.Mapper;
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(EmployeesDTO e)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Add(_mapper.Map<Employee>(e));
                _db.SaveChanges();
                TempData["Msg"] = "Registration successful";
                return RedirectToAction("Login");
            }
            ViewBag.Employees = _db.Employees.ToList();
            return View();
        }

        public ActionResult Login()
        {
            if (Session["LoggedInEmployeeUser"] != null)
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(EmployeesDTO employee)
        {
            var loggedInEmployee = _db.Employees.FirstOrDefault(emp => emp.EmpUser == employee.EmpUser && emp.EmpPass == employee.EmpPass);
            if (loggedInEmployee != null)
            {
                Session["LoggedInEmployeeUser"] = loggedInEmployee.EmpName;
                Session["LoggedInEmployeeID"] = loggedInEmployee.EmpId;
                return RedirectToAction("Dashboard");
            }
            ModelState.AddModelError("", "Invalid username or password");
            return View(employee);
        }

        public ActionResult Dashboard()
        {
            var allEmployees = _db.Employees.ToList();
            var employeeDTOs = _mapper.Map<List<EmployeesDTO>>(allEmployees);
            return View(employeeDTOs);
        }

        public ActionResult DistributionInformation()
        {
            var LoggedInEmployeeID = (int)Session["LoggedInEmployeeID"];
            var distributionRequests = _db.Collect_Requests
                                        .Where(cr => cr.Employee_id == LoggedInEmployeeID)
                                        .ToList();
            var requestDTOs = _mapper.Map<List<CollectRequestDTO>>(distributionRequests);
            return View(requestDTOs);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login");
        }

        public ActionResult AssignedRequests()
        {
            var LoggedInEmployeeID = (int)Session["LoggedInEmployeeID"];
            var assignedRequests = _db.Collect_Requests
                                .Where(cr => cr.Employee.EmpId == LoggedInEmployeeID &&
                                             cr.Employee_Status == "Assigned" &&
                                             cr.Distribution_Status == "Incomplete")
                                .ToList();
            return View(assignedRequests);
        }

        [HttpPost]
        public ActionResult Distribute(int collectRequestId)
        {
            var collectRequest = _db.Collect_Requests.Find(collectRequestId);
            if (collectRequest != null)
            {
                collectRequest.Distribution_Status = "Complete";
                _db.SaveChanges();
            }
            TempData["Msg"] = "Distribution completed";
            return RedirectToAction("Dashboard");
        }
    }
}