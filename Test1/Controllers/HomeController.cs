using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test1.Filters;

namespace Test1.Controllers
{
    [Authorize]
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

        [LogFilter]
        [HandleError(ExceptionType = typeof(NullReferenceException), View = "MyError")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            //throw new NullReferenceException();
            //PartialView()
            return View();
        }

        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult Serial(string lettercase)
        {
            var serial = "ABCJJQ23";
            if (lettercase == "lower")
                return Content(serial.ToLower());
            return Content(serial);
        }

        [ActionName("as-sa")]
        [Authorize(Users = "jomyav")]
        public ActionResult Something()
        {
            return View("Something");
            //return Json(new { id = 1, value = "asd" }, JsonRequestBehavior.AllowGet);
        }
    }
}