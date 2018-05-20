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
using Wolf.Lagash.Entities.map;
using Wolf.Lagash.Entities.history;

namespace LagashServer.helper
{
    public class LagashContext : DbContext
    {
        public DbSet<User> users { get; set; }

        public DbSet<Book> books { get; set; }
        public DbSet<BookCatalog> book_catalog { get; set; }
        public DbSet<BookEjemplar> book_ejemplar { get; set; }

        public DbSet<Thesis> thesis { get; set; }
        public DbSet<ThesisCatalog> thesis_catalog { get; set; }
        public DbSet<ThesisEjemplar> thesis_ejemplar { get; set; }

        public DbSet<Author> author { get; set; }
        public DbSet<Editorial> editorial { get; set; }

        public DbSet<AuthorMap> author_map { get; set; }
        public DbSet<EditorialMap> editorial_map { get; set; }
        public DbSet<Ejemplar> ejemplar { get; set; }

        public LagashContext() : base("LagashContext")
        {
        }

        public static LagashContext Create()
        {
            return new LagashContext();
        }
    }
}
