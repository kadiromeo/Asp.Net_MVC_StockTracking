using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockTrackingProject.Models.Entity
{
    public class Sale
    {
        public short Id { get; set; }
        public short Unit { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }

        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
    }
}