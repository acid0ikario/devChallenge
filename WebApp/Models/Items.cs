using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Items
    {
        public int sku { get; set; }
        public int qty { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
    }
}
