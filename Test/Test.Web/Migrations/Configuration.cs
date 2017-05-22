namespace Test.Web.Migrations
{
    using Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Test.Web.Data.TestDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(Test.Web.Data.TestDb context)
        {
            context.Orders.AddOrUpdate(
              p => p.Id,
              new Order { Id = 1, OrderNumber = "2017-001", OrderDate = new DateTime(2017,1,1,0,0,0) },
              new Order { Id = 2, OrderNumber = "2017-002", OrderDate = new DateTime(2017, 2, 10, 0, 0, 0) },
              new Order { Id = 3, OrderNumber = "2017-003", OrderDate = new DateTime(2017, 4, 20, 0, 0, 0) },
              new Order { Id = 4, OrderNumber = "2017-004", OrderDate = new DateTime(2017, 4, 20, 0, 0, 0) },
              new Order { Id = 5, OrderNumber = "2017-005", OrderDate = new DateTime(2017, 4, 25, 0, 0, 0) }
            );
            context.OrderDetails.AddOrUpdate(
                p => p.Id,
                new OrderDetail { OrderId = 1, ItemName = "Item1", Quantity=10, ItemPrice=10.99m },
                new OrderDetail { OrderId = 1, ItemName = "Item2", Quantity = 5, ItemPrice = 1.99m },
                new OrderDetail { OrderId = 1, ItemName = "Item3", Quantity = 3, ItemPrice = 0.99m },
                new OrderDetail { OrderId = 1, ItemName = "Item4", Quantity = 12, ItemPrice = 3.44m },
                new OrderDetail { OrderId = 2, ItemName = "Item2", Quantity = 15, ItemPrice = 5.35m },
                new OrderDetail { OrderId = 2, ItemName = "Item2", Quantity = 5, ItemPrice = 5.99m },
                new OrderDetail { OrderId = 2, ItemName = "Item5", Quantity = 11, ItemPrice = 2.75m },
                new OrderDetail { OrderId = 2, ItemName = "Item6", Quantity = 1, ItemPrice = 8.11m },
                new OrderDetail { OrderId = 2, ItemName = "Item7", Quantity = 15, ItemPrice = 5.35m },
                new OrderDetail { OrderId = 3, ItemName = "Item3", Quantity = 3, ItemPrice = 0.99m }
                );
        }
    }
}
