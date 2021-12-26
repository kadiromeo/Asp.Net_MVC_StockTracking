using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StockTrackingProject.Models.Entity;

namespace StockTrackingProject.Controllers
{
    [Authorize]
    public class SaleController : Controller
    {
        Context db = new Context();
        // GET: Sale
        public ActionResult Index()
        {
            var lst = db.Sales.ToList();
            return View(lst);
        }

        [HttpGet]
        public ActionResult AddNew()
        {
            List<SelectListItem> ver = (from i in db.Products.ToList()
                                        select new SelectListItem
                                        {
                                            Text = i.Name,
                                            Value = i.Id.ToString()
                                        }

                                             ).ToList();
            ViewBag.dgr = ver;

            List<SelectListItem> ver2 = (from i in db.Customers.ToList()
                                         select new SelectListItem
                                         {
                                             Text = i.Name + " " + i.Surname,
                                             Value = i.Id.ToString()
                                         }

                                          ).ToList();
            ViewBag.dgr2 = ver2;

            return View();
        }


        [HttpPost]
        public ActionResult AddNew(Sale p)
        {
            var ktg = db.Products.Where(m => m.Id == p.Product.Id).FirstOrDefault();
            var ktg2 = db.Customers.Where(m => m.Id == p.Customer.Id).FirstOrDefault();
           
            p.Customer = ktg2;
            p.Product = ktg;
            db.Sales.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Update()
        {
            List<SelectListItem> ver = (from i in db.Products.ToList()
                                        select new SelectListItem
                                        {
                                            Text = i.Name,
                                            Value = i.Id.ToString()
                                        }

                                             ).ToList();
            ViewBag.dgr = ver;

            List<SelectListItem> ver2 = (from i in db.Customers.ToList()
                                         select new SelectListItem
                                         {
                                             Text = i.Name + " " + i.Surname,
                                             Value = i.Id.ToString()
                                         }

                                          ).ToList();
            ViewBag.dgr2 = ver2;

            return View();
        }


        [HttpPost]
        public ActionResult Update(Sale p)
        {
            var ktg = db.Products.Where(m => m.Id == p.Id).FirstOrDefault();
            var ktg2 = db.Customers.Where(m => m.Id == p.Id).FirstOrDefault();

            p.Customer = ktg2;
            p.Product = ktg;
            var updt = db.Sales.Find(p.Id);
            updt.Unit = p.Unit;
            updt.Price = p.Price;
            updt.Date = p.Date;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {
            var ver = db.Sales.Where(m => m.Id == id).ToList();
            return View(ver);
        }

    }
}