using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Wargos.Lagash.Entities;
using LagashServer.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LagashServer.helper
{
    public class LagashContext : IdentityDbContext<IdentityUser>
    {
        public LagashContext() : base("LagashContext")
        {
            // Database.SetInitializer(new LagashInitializer());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<LagashContext, Configuration>());
        }

        //public DbSet<User> users { get; set; }
        //public DbSet<Client> Clients { get; set; }
        //public DbSet<RefreshToken> RefreshTokens { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}

        //public static LagashContext Create()
        //{
        //    return new LagashContext();
        //}
    }

    //public class LagashContext : DbContext
    //{
    //    public LagashContext() : base("LagashContext")
    //    {
    //        // Database.SetInitializer(new LagashInitializer());
    //        Database.SetInitializer(new MigrateDatabaseToLatestVersion<LagashContext, Configuration>());
    //    }

    //    public DbSet<User> users { get; set; }

    //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    //    }
    //}
}
