using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StockTrackingProject.Models.Entity;

namespace StockTrackingProject.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        // GET: Product
        Context db = new Context();
        public ActionResult Index()
        {
            var list = db.Products.ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult AddNew()
        {
            List<SelectListItem> ver = (from i in db.Categories.ToList()
                                        select new SelectListItem
                                        {
                                            Text = i.CategoryName,
                                            Value = i.Id.ToString()
                                        }

                                               ).ToList();
            ViewBag.dgr = ver;
            return View();
        }


        [HttpPost]
        public ActionResult AddNew(Product p)
        {
            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string extn = Path.GetExtension(Request.Files[0].FileName);
                string url = "/Photos/Product/" + filename + extn;
                Request.Files[0].SaveAs(Server.MapPath(url));
                p.Image = "/Photos/Product/" + filename + extn;

            }
            var ktg = db.Categories.Where(m => m.Id == p.Categories.Id).FirstOrDefault();
            p.Categories = ktg;
            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Update(int id)
        {
            List<SelectListItem> ver = (from i in db.Categories.ToList()
                                        select new SelectListItem
                                        {
                                            Text = i.CategoryName,
                                            Value = i.Id.ToString()
                                        }

                                               ).ToList();
            ViewBag.dgr = ver;
            var updt = db.Products.Find(id);
            return View("Update", updt);
        }


        [HttpPost]
        public ActionResult Update(Product p)
        {
            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string extn = Path.GetExtension(Request.Files[0].FileName);
                string url = "/Photos/Product/" + filename + extn;
                Request.Files[0].SaveAs(Server.MapPath(url));
                p.Image = "/Photos/Product/" + filename + extn;

            }
            var ktg = db.Categories.Where(m => m.Id == p.Categories.Id).FirstOrDefault();
            p.Categories = ktg;
            var updt = db.Products.Find(p.Id);
            updt.Name = p.Name;
            updt.Brand = p.Brand;
            updt.Stock = p.Stock;
            updt.Image = p.Image;
            updt.Price = p.Price;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            var dlt = db.Products.Find(id);
            db.Products.Remove(dlt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ProductList()
        {
            var lst = db.Products.ToList();
            return View(lst);
        }
    }
}