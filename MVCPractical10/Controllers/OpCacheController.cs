using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPractical10.Controllers
{
    public class OpCacheController : Controller
    {
        //Duration is in the second
        [OutputCache(Duration = 300)]
        public ActionResult Index()
        {
            ViewBag.TodaysDateTime = DateTime.Now;
            return View();
        }
    }
}