using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LagashServer.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Director { get; set; }
    }

    public class MoviesAppContext : DbContext
    {

        public DbSet<Movie> Movies { get; set; }

    }
}