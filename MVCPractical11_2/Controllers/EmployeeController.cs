using MVCPractical11_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPractical11_2.Controllers
{
    public class EmployeeController : Controller
    {
        static List<Employee> empList = new List<Employee>()
        {
            new Employee(){Id=1, Name="Parthiv", DOB=("2002-03-29").ToString(), Address="Rajkot"},
            new Employee(){Id=2, Name="Meet", DOB=("2001-09-05").ToString(), Address="Ahmedabad"}
        };

        public ActionResult Index()
        {
            return View(empList);
        }

        public ActionResult Details(int id)
        {
            return View(empList.Where(e=>e.Id==id).FirstOrDefault());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                emp.Id = empList.Count() + 1;
                empList.Add(emp);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View(empList.Where(e => e.Id == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            if(ModelState.IsValid)
            {
                var edited = empList.Where(e => e.Id == emp.Id).FirstOrDefault();

                emp.Id = edited.Id;
                empList.Add(emp);

                empList.Remove(edited);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            empList.Remove(empList.Where(e=>e.Id==id).FirstOrDefault());
            return RedirectToAction("Index");
        }
    }
}