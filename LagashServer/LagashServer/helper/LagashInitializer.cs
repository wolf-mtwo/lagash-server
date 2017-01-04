using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Wargos.Lagash.Entities;

namespace LagashServer.helper
{
    public class LagashInitializer : DropCreateDatabaseAlways<LagashContext>
    {
        protected override void Seed(LagashContext context)
        {
            IList<User> defaultUsers = new List<User>();
            defaultUsers.Add(new User() { name = "Wargos", cel = "70156988", email = "wolf@wolf.com", password = "bf4397d8b4dc061e1b6d191a352e9134" });

            foreach (User user in defaultUsers)
                context.users.Add(user);

            base.Seed(context);
        }
    }
}