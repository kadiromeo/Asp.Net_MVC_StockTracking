using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StockTrackingProject.Models.Entity;

namespace StockTrackingProject.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        // GET: Category
        Context db = new Context();
        public ActionResult Index()
        {
            var list = db.Categories.ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult AddNew()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNew(Category add)
        {
            db.Categories.Add(add);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var updt = db.Categories.Find(id);
            return View("Update", updt);
        }

        [HttpPost]
        public ActionResult Update(Category p)
        {
            var updt = db.Categories.Find(p.Id);
            updt.CategoryName = p.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            var dlt = db.Categories.Find(id);
            db.Categories.Remove(dlt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}