using LagashServer.helper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Wolf.Lagash.Entities;

namespace LagashServer.Migrations
{
    internal sealed class MigrationsConfiguration : DbMigrationsConfiguration<LagashContext>
    {
        public MigrationsConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LagashContext context)
        {
            context.users.AddOrUpdate(
                 o => o._id,
                 new User() { _id = 1, name = "Wargos", cel = "70156988", email = "wolf@wolf.com", password = "bf4397d8b4dc061e1b6d191a352e9134", role = "super" }
             );
        }
    }
}