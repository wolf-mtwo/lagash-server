using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolf.Lagash.Entities.helper;

namespace Wolf.Lagash.Entities.books
{
    public class Search
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Autor { get; set; }
        public string Image { get; set; }
        public int RowNumber { get; set; }
        public int Total { get; set; }
    }
}
