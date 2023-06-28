using MVCPractical10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPractical10.Controllers
{
    public class ActionResultDemoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ContentResult ContentResultDemo()
        {
            return Content("<h1>This string is returned by ContentResult.</h1>");
        }

        public FileResult FileContentResultDemo()
        {
            return File(Url.Content("~/Web.config"), "text");
        }

        public EmptyResult EmptyResultDemo()
        {
            return null;
        }

        public ActionResult JavaScriptResultDemo()
        {
            return View();
        }

        public JavaScriptResult JavaScriptResultDemo1()
        {
            var alertMsg = "alert('You are rendering JavaScript Result from Action Method.');";
            return new JavaScriptResult() { Script = alertMsg };
        }

        public JsonResult JsonResultDemo()
        {
            var employee = new Employee() {ID = 1, Name ="Parthiv", Department="IT", Salary=50000, Gender="Male", Age=21, City="Rajkot"};
            return Json(employee, "application/json",JsonRequestBehavior.AllowGet);
        }
    }
}