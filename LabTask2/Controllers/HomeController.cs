using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using labtask1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Education()
        {
            ViewBag.Message = "Education";

            var ssc = new Education();
            ssc.Degree = "Secondary School Certificate";
            ssc.Year = "2016-2017";
            ssc.Instituitions = "Habiganj Government High School, Habiganj";

            var hsc = new Education();
            hsc.Degree = "Higher Secondary Certificate";
            hsc.Year = "2018-2019";
            hsc.Instituitions = "Sylhet MC College, Sylhet.";

            var bsc = new Education();
            bsc.Degree = "Bachelor of Science in Computer Science & Engineering";
            bsc.Year = "2021-2024";
            bsc.Instituitions = "American International University - Bangladesh, Dhaka";

            Education[] Satyajit = new Education[] { ssc, hsc, bsc };

            ViewBag.Education = Satyajit;
            return View();
        }
        public ActionResult Projects()
        {
            ViewBag.Message = "Projects";

            var p1 = new Projects();
            p1.course = "Web Technologies";
            p1.projects = "An E-learning website";
            p1.descriptions = "Platform Like DevWiz";

            var p2 = new Projects();
            p2.course = "Object Oriented Programming 2";
            p2.projects = "Blood Bank Management System";
            p2.descriptions = "A windows application using .net form.";

            var p3 = new Projects();
            p3.course = "Software Engineering";
            p3.projects = "Income-Tax Assessment Software";
            p3.descriptions = "It was like a SRS document.";

            var p4 = new Projects();
            p4.course = "Object Oriented Programming 1";
            p4.projects = "Petrol Pump Management System";
            p4.descriptions = "Very Basic java projects.";

            Projects[] projectarray = new Projects[] { p1, p2, p3, p4 };

            ViewBag.Projects = projectarray;
            return View();
        }
        public ActionResult PersonalInfo()
        {
            ViewBag.Message = "Personal Information";
            return View();
        }
        public ActionResult Ref()
        {
            ViewBag.Message = "References";

            return View();
        }
    }
}