using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPractical10.Controllers
{
    public class ExceptionDemoController : Controller
    {
        [HandleError(ExceptionType = typeof(DivideByZeroException), View = "~/Views/Error/DivideByZero.cshtml")]
        public ActionResult Index()
        {
            int num1 = 10, num2 = 0;
            var result = num1 / num2;
            ViewBag.Division = result;
            return View();
        }
    }
}