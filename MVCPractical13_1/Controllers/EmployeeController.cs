using MVCPractical13_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPractical13_1.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            using(var context = new EmployeeDBContext())
            {
                var employeeData = context.Employees.ToList();
                return View(employeeData);
            } 
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            using (var context = new EmployeeDBContext())
            {
                context.Employees.Add(emp);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }


        [HttpGet]
        public ActionResult Details(int id)
        {
            using (var context = new EmployeeDBContext())
            {
                var emp = context.Employees.Where(e => e.Id == id).FirstOrDefault();
                return View(emp);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using(var context = new EmployeeDBContext())
            {
                var emp = context.Employees.Where(e=>e.Id == id).FirstOrDefault();
                return View(emp);
            }
        }

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            using (var context = new EmployeeDBContext())
            {
                var employeeData = context.Employees.Where(e => e.Id == emp.Id).FirstOrDefault();
                employeeData.Name = emp.Name;
                employeeData.DOB = emp.DOB;
                employeeData.Age = emp.Age;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (var context = new EmployeeDBContext())
            {
                var emp = context.Employees.Where(e => e.Id == id).FirstOrDefault();
                return View(emp);
            }
        }

        [HttpPost]
        public ActionResult Delete(Employee emp)
        {
            using (var context = new EmployeeDBContext())
            {
                var deletedEmp = context.Employees.Where(e => e.Id == emp.Id).FirstOrDefault();
                context.Employees.Remove(deletedEmp);
                context.SaveChanges();

            }
            return RedirectToAction("Index");
        }
    }
}