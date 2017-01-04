using LagashServer.helper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Wargos.Lagash.Entities;

namespace LagashServer.Migrations
{
    //internal sealed class Configuration : DbMigrationsConfiguration<LagashContext>
    internal sealed class Configuration : DbMigrationsConfiguration<LagashContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LagashContext context)
        {
            context.users.AddOrUpdate(
                 o => o._id,
                 new User() { name = "Wargos", cel = "70156988", email = "wolf@wolf.com", password = "bf4397d8b4dc061e1b6d191a352e9134" }
             );
            //base.Seed(context);
        }
    }
}