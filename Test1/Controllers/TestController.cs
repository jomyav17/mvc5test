using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test1.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View("TestView");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult submitTest()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}