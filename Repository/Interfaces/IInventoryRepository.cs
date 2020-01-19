using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
   public interface IInventoryRepository
    {
        List<Items> GetlistaItems(int sku = 0);
        Items CreateItem(Items item);
        Items UpdateItem(Items item);
        void DecreseQty(int sku, int qty);
        void IncreseQty(int sku, int qty);
    }
}
