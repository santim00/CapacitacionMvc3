using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalMVC.Models;

namespace HospitalMVC.Controllers
{
    public class HomeController : Controller
    {
        

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to my Clinic App!";

            ViewBag.Intro = "Para interactuar con la aplicación";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
