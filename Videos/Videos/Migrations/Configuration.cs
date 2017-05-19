namespace Videos.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Videos.Models.VideoDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Videos.Models.VideoDb context)
        {
            context.Videos.AddOrUpdate(
              p => p.Title,
              new Video() { Title = "MVC4", Length=120  },
              new Video { Title = "LINQ", Length = 180 },
              new Video { Title = "ASP.NET", Length =240 }
            );

        }
    }
}
