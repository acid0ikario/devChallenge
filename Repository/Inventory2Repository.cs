using DataAccess.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class Inventory2Repository : IInventoryRepository
    {
        public Items CreateItem(Items item)
        {
            throw new NotImplementedException();
        }

        public void DecreseQty(int sku, int qty)
        {
            throw new NotImplementedException();
        }

        public List<Items> GetAvalibleSkus()
        {
            throw new NotImplementedException();
        }

        public Items GetItembyId(int sku)
        {
            throw new NotImplementedException();
        }

        public List<Items> GetlistaItems(int sku = 0)
        {
            throw new NotImplementedException();
        }

        public int GetStock(int sku)
        {
            throw new NotImplementedException();
        }

        public void IncreseQty(int sku, int qty)
        {
            throw new NotImplementedException();
        }

        public Items UpdateItem(Items item)
        {
            throw new NotImplementedException();
        }
    }
}
