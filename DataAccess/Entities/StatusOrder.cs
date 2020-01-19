using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities
{
    public class StatusOrder
    {
        [Key]
        public string statusId { get; set; }
        public string description { get; set; }

      
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<OrdersHistory> OrdersHistories { get; set; }
    }
}
