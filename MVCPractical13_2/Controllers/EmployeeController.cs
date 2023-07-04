using Microsoft.Ajax.Utilities;
using MVCPractical13_2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPractical13_2.Controllers
{
    public class EmployeeController : Controller, IDisposable
    {
        private EmployeeDesignationDBContext context = new EmployeeDesignationDBContext();
        public ActionResult Index()
        {
            var employeeList = context.Employees.Include(e=>e.Designation).ToList();
            return View(employeeList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.DesignationId = new SelectList(context.Designations, "Id", "Designation");
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeModel employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var employee = context.Employees.Where(e => e.Id == id).Include(d=>d.Designation).FirstOrDefault();
            
            return View(employee);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var employee = context.Employees.Where(e => e.Id == id).Include(d => d.Designation).FirstOrDefault();
            ViewBag.DesignationId = new SelectList(context.Designations, "Id", "Designation", employee.DesignationId);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeModel employee)
        {
            var editedEmp = context.Employees.Where(e => e.Id == employee.Id).FirstOrDefault();
            editedEmp.FirstName = employee.FirstName;
            editedEmp.MiddleName = employee.MiddleName;
            editedEmp.LastName = employee.LastName;
            editedEmp.DOB = employee.DOB;
            editedEmp.MobileNumber = employee.MobileNumber;
            editedEmp.Address = employee.Address;
            editedEmp.Salary = employee.Salary;
            editedEmp.DesignationId = employee.DesignationId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var employee = context.Employees.Where(e => e.Id == id).Include(d => d.Designation).FirstOrDefault();
            return View(employee);
        }

        [HttpPost]
        public ActionResult Delete(EmployeeModel employee)
        {
            var deletedemp = context.Employees.Where(e=>e.Id== employee.Id).FirstOrDefault();
            context.Employees.Remove(deletedemp);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Query1()
        {
            List<Query1> query1s = new List<Query1>();
            var query1Result = context.Employees.Include(d => d.Designation).ToList();
            foreach (var employee in query1Result)
            {
                Query1 q1 = new Query1();
                q1.FirstName = employee.FirstName;
                q1.MiddleName = employee.MiddleName;
                q1.LastName = employee.LastName;
                q1.Designation = employee.Designation.Designation;
                q1.DOB = employee.DOB;
                q1.MobileNumber = employee.MobileNumber;
                q1.Salary = employee.Salary;
                q1.Address = employee.Address;
                query1s.Add(q1);
            }
            return View(query1s);
        }

        [HttpGet]
        public ActionResult Query2()
        {
            List<Query2> query2s = new List<Query2>();
            var countEmployees = context.Employees.Include(e=>e.Designation.Designation).GroupBy(e=>e.DesignationId).ToList();
            foreach (IGrouping<string, Query2> employee in query2s)
            {
                Query2 q2 = new Query2();
                q2.DesignationName = employee.Key;
                q2.CountNumber = employee.Count();
                query2s.Add(q2);
            }
            return View(query2s);
        }
    }
}