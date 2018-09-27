using DataLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MongoUI.Controllers
{
    public class HomeController : Controller
    {

        //private StudentLogic student;

        //public HomeController()
        //{
        //    student = new StudentLogic();
        //}

        public ActionResult Index()
        {
            //var result = student.GetAllStudent();
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
    }
}