using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using StockTrackingProject.Models.Entity;

namespace StockTrackingProject.Controllers
{
    public class AdminLoginController : Controller
    {
        Context db = new Context();
        // GET: AdminLogin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin a)
        {
            var identity = db.Admins.FirstOrDefault(m => m.userName.Equals(a.userName) && m.Password.Equals(a.Password));

            if (identity != null)
            {
                FormsAuthentication.SetAuthCookie(identity.userName, false);
                Session["Admin"] = identity.Name.ToString();
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewBag.Message = "Username or password is incorrect...";
                return View();

            }

        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "AdminLogin");
        }
    }
}