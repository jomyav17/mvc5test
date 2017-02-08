using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test1.Controllers
{
    [Authorize]
    public class BankingController : Controller
    {
        // GET: Banking
        public ActionResult Index()
        {
            return View("Banking");
        }
    }
}