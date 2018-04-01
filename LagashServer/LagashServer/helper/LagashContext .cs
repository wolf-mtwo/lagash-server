using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Wolf.Lagash.Entities;
//using LagashServer.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;
using Wolf.Lagash.Entities.books;

namespace LagashServer.helper
{
    public class LagashContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<BookCatalog> catalogs { get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<BookEjemplar> ejemplares { get; set; }

        public LagashContext() : base("LagashContext")
        {
        }

        public static LagashContext Create()
        {
            return new LagashContext();
        }
    }
}
