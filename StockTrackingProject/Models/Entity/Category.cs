using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockTrackingProject.Models.Entity
{
    public class Category
    {
        public short Id { get; set; }
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; }
    }
}