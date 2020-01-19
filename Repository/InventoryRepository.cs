using DataAccess.Context;
using DataAccess.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        public readonly DevPGSContext _dbContext;
        public InventoryRepository(DevPGSContext pGSContext)
        {
            _dbContext = pGSContext;
        }

        public Items CreateItem(Items item)
        {
            throw new NotImplementedException();
        }

        public List<Items> GetListaBySku(int sku)
        {
            throw new NotImplementedException();
        }

        public List<Items> GetlistaItems()
        {
            throw new NotImplementedException();
        }

        public List<Items> GetlistaItems(int sku = 0)
        {
            throw new NotImplementedException();
        }
    }
}
