using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
   public  class OrdersHistory
    {
        public int idHistory { get; set; }
        public int orderId { get; set; }
        public System.DateTime creationDate { get; set; }
        public string statusId { get; set; }

        public virtual Orders Order { get; set; }
        public virtual StatusOrder StatusOrder { get; set; }
    }
}
