using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

            return View();
        }
        public ActionResult Projects()
        {
            ViewBag.Message = "Projects";

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