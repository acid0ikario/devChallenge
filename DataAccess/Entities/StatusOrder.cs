using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class StatusOrder
    {
        public string statusId { get; set; }
        public string description { get; set; }

      
        public virtual ICollection<OrdersHistory> OrdersHistories { get; set; }
    }
}
