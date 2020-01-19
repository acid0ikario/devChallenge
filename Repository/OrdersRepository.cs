using DataAccess.Context;
using DataAccess.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly DevPGSContext _dbContext;
        private readonly IInventoryRepository _Inventory;

        public OrdersRepository(DevPGSContext pGSContext, IInventoryRepository inventory)
        {
            _dbContext = pGSContext;
            _Inventory = inventory;
        }


        public List<Orders> GetListaOrders(string userId="")
        {
            return _dbContext.Orders.Where(x => x.userId == userId || userId == "").ToList();
        }

        public void SaveLogOrder(int orderId, string statusOrder)
        {
            OrdersHistory orderH = new OrdersHistory();
            orderH.orderId = orderId;
            orderH.statusId = statusOrder;
            orderH.creationDate = DateTime.Now;
            _dbContext.OrdersHistory.Add(orderH);
            _dbContext.SaveChanges();
        }

        Orders IOrdersRepository.CancelOrder(int orderId)
        {
            Orders order = _dbContext.Orders.FirstOrDefault(x => x.orderId == orderId );
            if (order != null)
            {
                order.statusId = "CAN";
                _dbContext.Orders.Update(order);
                _dbContext.SaveChanges();
                _Inventory.IncreseQty(order.sku, order.qty);
                SaveLogOrder(orderId, order.statusId);
                return order;
            }
            return null;
        }

        Orders IOrdersRepository.CreateOrder(int sku, int qty, decimal price, string userid)
        {
            Orders order = new Orders();
            order.sku = sku;
            order.qty = qty;
            order.price = price;
            order.userId = userid;
            order.statusId = "OPN";
            _Inventory.DecreseQty(order.sku, order.qty);
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
            SaveLogOrder(order.orderId, order.statusId);
            return order;
        }
    }
}
