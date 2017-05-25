using Orders.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Orders.Web.DataLayer
{
    public class OrdersDatabase: DbContext
    {
        public OrdersDatabase():base("DefaultConnection")
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}