using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockTrackingProject.Models.Entity
{
    public class Customer
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Image { get; set; }
        public string PhoneNumber { get; set; }
        public string address { get; set; }

        public virtual Sale Sales { get; set; }
    }
}