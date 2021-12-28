using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using StockTrackingProject.Models.Entity;

namespace StockTrackingProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        Context db = new Context();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(Contact p)
        {
         
                MailMessage mail = new MailMessage();
                mail.To.Add("example@gmail.com");
                mail.From = new MailAddress("example@gmail.com");
                mail.Subject = "Have a new message!" + p.Subject;
                mail.Body = "to the person concerned"+" "+ p.Name + "-" + p.Surname +" "+ "sent you a message <b>" + p.Message;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.Credentials = new NetworkCredential("example@gmail.com", "password");
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.Send(mail);


            try
            {
                smtp.Send(mail);
                ViewBag.Alert = "Your request has been submitted!";

            }
            catch (Exception)
            {
                ViewBag.Alert = "Your request failed!";

                throw;
            }

            db.Contacts.Add(p);
            db.SaveChanges();
            return View();

        }
    }
}
