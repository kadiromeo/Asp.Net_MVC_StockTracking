using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockTrackingProject.Models.Entity
{
    public class Product
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public short Stock { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }

        public short ProdCat { get; set; }
        public virtual Category Categories { get; set; }

        public virtual Sale Sales { get; set; }
    }
}