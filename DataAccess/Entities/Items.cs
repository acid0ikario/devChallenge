using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Items
    {
        public int sku { get; set; }
        public int qty { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
