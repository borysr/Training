namespace Orders.Web.Migrations
{
    using Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Orders.Web.DataLayer.OrdersDatabase>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Orders.Web.DataLayer.OrdersDatabase context)
        {
            context.Orders.AddOrUpdate(
              p => p.Id,
              new Order { Id = 1, OrderNumber = "2017-001", OrderDate = new DateTime(2017, 1, 1, 0, 0, 0) },
              new Order { Id = 2, OrderNumber = "2017-002", OrderDate = new DateTime(2017, 2, 10, 0, 0, 0) },
              new Order { Id = 3, OrderNumber = "2017-003", OrderDate = new DateTime(2017, 4, 20, 0, 0, 0) },
              new Order { Id = 4, OrderNumber = "2017-004", OrderDate = new DateTime(2017, 4, 20, 0, 0, 0) },
              new Order { Id = 5, OrderNumber = "2017-005", OrderDate = new DateTime(2017, 4, 25, 0, 0, 0) }
            );
            context.OrderDetails.AddOrUpdate(
                p => p.Id,
                new OrderDetail { OrderId = 1, LineNumber=1, Description = "Item1", Price = 10.99m },
                new OrderDetail { OrderId = 1, LineNumber=2, Description = "Item2", Price = 1.99m },
                new OrderDetail { OrderId = 1, LineNumber=3, Description = "Item3", Price = 0.99m },
                new OrderDetail { OrderId = 1, LineNumber=4, Description = "Item4", Price = 3.44m },
                new OrderDetail { OrderId = 2, LineNumber=1, Description = "Item1", Price = 5.35m },
                new OrderDetail { OrderId = 2, LineNumber=2, Description = "Item2", Price = 5.99m },
                new OrderDetail { OrderId = 2, LineNumber=3, Description = "Item3", Price = 2.75m },
                new OrderDetail { OrderId = 2, LineNumber=4, Description = "Item4", Price = 8.11m },
                new OrderDetail { OrderId = 2, LineNumber=5, Description = "Item5", Price = 5.35m },
                new OrderDetail { OrderId = 3, LineNumber=1, Description = "Item3", Price = 0.99m }
                );
        }
    }
}
