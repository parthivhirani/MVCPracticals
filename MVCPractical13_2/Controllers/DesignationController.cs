using MVCPractical13_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPractical13_2.Controllers
{
    public class DesignationController : Controller
    {
        private EmployeeDesignationDBContext db = new EmployeeDesignationDBContext();
        public ActionResult Index()
        {
            var designationList = db.Designations.ToList();
            return View(designationList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DesignationModel model)
        {
            if(ModelState.IsValid)
            {
                db.Designations.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
            
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = db.Designations.Where(d=>d.Id==id).FirstOrDefault();
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Designations.Where(d=>d.Id == id).FirstOrDefault();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(DesignationModel model)
        {
            if(ModelState.IsValid)
            {
                var editedDesignation = db.Designations.Where(d=>d.Id== model.Id).FirstOrDefault();
                editedDesignation.Designation = model.Designation;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
            
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var deletedDesignation = db.Designations.Where(d => d.Id == id).FirstOrDefault();
            return View(deletedDesignation);
        }

        [HttpPost]
        public ActionResult Delete(DesignationModel designation)
        {
            var deletedDesignation = db.Designations.Where(d => d.Id == designation.Id).FirstOrDefault();
            db.Designations.Remove(deletedDesignation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}