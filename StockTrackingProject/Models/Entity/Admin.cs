using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockTrackingProject.Models.Entity
{
    public class Admin
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string userName { get; set; }
        public string eMail { get; set; }
        public string Password { get; set; }
    }
}