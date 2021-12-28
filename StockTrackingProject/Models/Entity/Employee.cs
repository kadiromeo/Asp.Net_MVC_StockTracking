using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockTrackingProject.Models.Entity
{

    public class Employee
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Age { get; set; }
        public decimal Wage { get; set; }
        public string Department { get; set; }
    }
}