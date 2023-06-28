using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPractical10.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index(string name)
        {
            ViewBag.EName = name;
            return View();
        }
    }
}