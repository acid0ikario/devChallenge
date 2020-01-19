using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
  public  interface IOrdersRepository
    {
        Orders CreateOrder(int sku, int qty, decimal price, string userid);
        Orders CancelOrder(int orderId);
        void SaveLogOrder(int orderId, string statusOrder);
        List<Orders> GetListaOrders(string userId="");
    }
}
