using DataAccess.Context;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        public readonly DevPGSContext _dbContext;
        public OrdersRepository(DevPGSContext pGSContext)
        {
            _dbContext = pGSContext;
        }

        public bool CancelOrder(int orderId, string userid)
        {
            throw new NotImplementedException();
        }

        public bool CreateOrder(int sku, int qty, string userid)
        {
            throw new NotImplementedException();
        }
    }
}
