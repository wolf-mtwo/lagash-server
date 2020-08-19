using System.Data.Entity;
using Wolf.Lagash.Entities;
using Wolf.Lagash.Entities.booking;
using Wolf.Lagash.Entities.books;
using Wolf.Lagash.Entities.helper.author;
using Wolf.Lagash.Entities.helper.editorial;
using Wolf.Lagash.Entities.helper.faculties;
using Wolf.Lagash.Entities.helper.reader;
using Wolf.Lagash.Entities.helper.tutor;
using Wolf.Lagash.Entities.magazine;
using Wolf.Lagash.Entities.newspaper;
using Wolf.Lagash.Entities.thesis;

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

        public DbSet<Magazine> magazines { get; set; }
        public DbSet<MagazineCatalog> magazine_catalog { get; set; }
        public DbSet<MagazineEjemplar> magazine_ejemplar { get; set; }

        public DbSet<Newspaper> newspapers { get; set; }
        public DbSet<NewspaperCatalog> newspaper_catalog { get; set; }
        public DbSet<NewspaperEjemplar> newspaper_ejemplar { get; set; }

        public DbSet<Faculty> faculties { get; set; }
        public DbSet<Carrer> carrers { get; set; }

        public DbSet<Tutor> tutor { get; set; }
        public DbSet<Author> author { get; set; }
        public DbSet<Editorial> editorial { get; set; }
        public DbSet<Reader> reader { get; set; }

        public DbSet<Booking> booking { get; set; }
        public DbSet<AuthorMap> author_map { get; set; }
        public DbSet<EditorialMap> editorial_map { get; set; }
        //public DbSet<Ejemplar> ejemplar { get; set; }
       // public DbSet<Search> search { get; set; }

        public LagashContext() : base("LagashContext")
        {
            // IMPORTANT: comment this line if you migrate the database or add new columns in models
            Database.SetInitializer<LagashContext>(null);
        }

        public static LagashContext Create()
        {
            return new LagashContext();
        }
    }
}
