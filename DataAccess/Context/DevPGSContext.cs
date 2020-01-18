using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Context
{
    public class DevPGSContext: DbContext
    {
        public DevPGSContext(DbContextOptions<DevPGSContext> options) : base(options)
        {

        }

        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrdersHistory> OrdersHistory { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<StatusOrder> StatusOrders { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
