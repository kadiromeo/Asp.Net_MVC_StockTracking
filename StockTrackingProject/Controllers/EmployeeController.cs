using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StockTrackingProject.Models.Entity;

namespace StockTrackingProject.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        Context db = new Context();
        // GET: Employee
        public ActionResult Index()
        {
            var lst = db.Employees.ToList();
            return View(lst);
        }

        [HttpGet]
        public ActionResult AddNew()
        {
            return View();

        }

        [HttpPost]
        public ActionResult AddNew(Employee p)
        {
            db.Employees.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var updt = db.Employees.Find(id);
            return View("Update",updt);

        }

        [HttpPost]
        public ActionResult Update(Employee p)
        {
            var updt = db.Employees.Find(p.Id);
            updt.Name = p.Name;
            updt.Surname = p.Surname;
            updt.Age = p.Age;
            updt.Wage = p.Wage;
            updt.Department = p.Department;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var dlt = db.Employees.Find(id);
            db.Employees.Remove(dlt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}