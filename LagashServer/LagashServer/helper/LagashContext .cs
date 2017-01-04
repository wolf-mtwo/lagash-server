using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Wargos.Lagash.Entities;

namespace LagashServer.helper
{
    public class LagashContext : DbContext
    {
        public LagashContext() : base("LagashContext")
        {
        }

        public DbSet<User> users { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

}
