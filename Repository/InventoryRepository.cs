using DataAccess.Context;
using DataAccess.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        public readonly DevPGSContext _dbContext;
        public InventoryRepository(DevPGSContext pGSContext)
        {
            _dbContext = pGSContext;
        }

        public List<Items> GetlistaItems(int sku = 0)
        {
            return _dbContext.Items.Where(x => x.sku == sku || sku == 0).ToList();
        }

        public Items CreateItem(Items item)
        {
            _dbContext.Items.Add(item);
            _dbContext.SaveChanges();
            return item;
        }
        
        public void IncreseQty(int sku, int qty)
        {
            Items item = _dbContext.Items.Find(sku);
            item.qty = item.qty + qty;
            _dbContext.Items.Update(item);
            _dbContext.SaveChanges();
        }

        public void DecreseQty(int sku, int qty)
        {
            Items item = _dbContext.Items.Find(sku);
            item.qty = item.qty - qty;
            if(item.qty < 0)
            {
                throw new Exception("no hay suficiente items en stock");
            }
            _dbContext.Items.Update(item);
            _dbContext.SaveChanges();
        }

        public Items UpdateItem(Items item)
        {
            _dbContext.Items.Update(item);
            _dbContext.SaveChanges();
            return item;
        }
    }
}
