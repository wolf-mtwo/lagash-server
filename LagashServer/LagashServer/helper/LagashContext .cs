using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Wolf.Lagash.Entities;
using LagashServer.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LagashServer.helper
{
    //public class LagashContext : IdentityDbContext<IdentityUser>
    public class LagashContext : DbContext
    {
        public LagashContext() : base("LagashContext")
        {
            //Database.SetInitializer<LagashContext>(null);
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<LagashContext, MigrationsConfiguration>());
        }

        public DbSet<User> users { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<LagashContext>(null);
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public static LagashContext Create()
        {
            return new LagashContext();
        }
    }
}
