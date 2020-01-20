using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
  public  interface IOrdersRepository
    {
        Orders CreateOrder(Orders order);
        Orders CancelOrder(Orders pOrder);
        void SaveLogOrder(int orderId, string statusOrder);
        List<Orders> GetListaOrders(string userId="");
    }
}
