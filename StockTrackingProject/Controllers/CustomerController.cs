using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StockTrackingProject.Models.Entity;

namespace StockTrackingProject.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        Context db = new Context();
        // GET: Customer
        public ActionResult Index()
        {
            var list = db.Customers.ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult AddNew()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNew(Customer add)
        {
            db.Customers.Add(add);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Update(int id)
        {
            var updt = db.Customers.Find(id);
            return View("Update", updt);
        }

        [HttpPost]
        public ActionResult Update(Customer p)
        {
            var updt = db.Customers.Find(p.Id);
            updt.Name = p.Name;
            updt.Surname = p.Surname;
            updt.PhoneNumber = p.PhoneNumber;
            updt.address = p.address;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var dlt = db.Customers.Find(id);
            db.Customers.Remove(dlt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}