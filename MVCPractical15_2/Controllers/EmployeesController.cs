using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCPractical15_2.Models;

namespace MVCPractical15_2.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private FormAuthenticationDBContext db = new FormAuthenticationDBContext();

        // GET: Employees
        public ActionResult Index()
        {
            return View(db.EmployeeFs.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeF employeeF = db.EmployeeFs.Find(id);
            if (employeeF == null)
            {
                return HttpNotFound();
            }
            return View(employeeF);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Designation,Salary")] EmployeeF employeeF)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeFs.Add(employeeF);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeF);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeF employeeF = db.EmployeeFs.Find(id);
            if (employeeF == null)
            {
                return HttpNotFound();
            }
            return View(employeeF);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Designation,Salary")] EmployeeF employeeF)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeF).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeF);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeF employeeF = db.EmployeeFs.Find(id);
            if (employeeF == null)
            {
                return HttpNotFound();
            }
            return View(employeeF);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeF employeeF = db.EmployeeFs.Find(id);
            db.EmployeeFs.Remove(employeeF);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
