using MVCPractical14.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace MVCPractical14.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpPost]
        public JsonResult Index(string search)
        {
            using (var context = new MVCPractical14Entities())
            {
                var searchedEmployees = context.EmployeePractical14.Where(e => e.Name.Contains(search)).ToList();
                return Json(searchedEmployees);
            }
        }

        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            int recordsPerPage = 2;
            using (var context = new MVCPractical14Entities())
            {
                var pageResult = context.EmployeePractical14.ToList().ToPagedList(page, recordsPerPage);
                return View(pageResult);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeePractical14 emp)
        {
            if(ModelState.IsValid)
            {
                using (var context = new MVCPractical14Entities())
                {
                    context.EmployeePractical14.Add(emp);
                    context.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            using(var context = new MVCPractical14Entities())
            {
                var getEmployee = context.EmployeePractical14.Where(e => e.Id == id).FirstOrDefault();
                return View(getEmployee);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (var context = new MVCPractical14Entities())
            {
                var getEmployee = context.EmployeePractical14.Where(e => e.Id == id).FirstOrDefault();
                return View(getEmployee);
            }
        }

        [HttpPost]
        public ActionResult Edit(EmployeePractical14 emp)
        {
            if (ModelState.IsValid)
            {
                using (var context = new MVCPractical14Entities())
                {
                    var getEmployee = context.EmployeePractical14.Where(e => e.Id == emp.Id).FirstOrDefault();
                    getEmployee.Name = emp.Name;
                    getEmployee.DOB = emp.DOB;
                    getEmployee.Age = emp.Age;
                    context.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using(var context = new MVCPractical14Entities())
            {
                var getEmployee = context.EmployeePractical14.Where(e => e.Id == id).FirstOrDefault();
                return View(getEmployee);
            }
        }

        [HttpPost]
        public ActionResult Delete(EmployeePractical14 emp)
        {
            using(var context = new MVCPractical14Entities())
            {
                var deletedEmployee = context.EmployeePractical14.Where(e => e.Id == emp.Id).FirstOrDefault();
                context.EmployeePractical14.Remove(deletedEmployee);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}