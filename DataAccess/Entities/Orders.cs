using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orders
    {
        [Key]
        public int orderId { get; set; }
        public string shippingAddress { get; set; }
        public int qty { get; set; }

        public virtual Items Item { get; set; }
        public virtual Users User { get; set; }
       
        public virtual ICollection<OrdersHistory> OrdersHistories { get; set; }
    }
}
