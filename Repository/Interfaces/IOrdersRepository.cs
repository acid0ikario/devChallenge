using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
  public  interface IOrdersRepository
    {
        bool CreateOrder(int sku, int qty, string userid);
        bool CancelOrder(int orderId, string userid);
    }
}
