using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Test.Domain;

namespace Test.Web.Data
{
    public class TestDb: DbContext
    {
        public TestDb():base("DefaultConnection")
        {

        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}