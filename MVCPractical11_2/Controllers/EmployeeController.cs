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
            new Employee(){Id=2, Name="Meet", DOB=("05-09-2001").ToString(), Address="Ahmedabad"}
        };

        public ActionResult Index()
        {
            return View(empList);
        }

        public ActionResult Details(int id)
        {
            return View(empList[id - 1]);
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
            }
            return View(emp);
        }

        public ActionResult Edit(int id)
        {
            return View(empList[id - 1]);
        }

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            var edited = empList[emp.Id - 1];

            emp.Id = edited.Id;
            empList.Add(emp);

            empList.Remove(edited);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            empList.Remove(empList[id - 1]);
            return RedirectToAction("Index");
        }
    }
}