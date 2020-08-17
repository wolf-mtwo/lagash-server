using System.ComponentModel.DataAnnotations;
using Wolf.Lagash.Entities.helper;

namespace Wolf.Lagash.Entities.books
{
    public class Book : Material
    {
        [StringLength(20)]
        public string isbn { get; set; }

        public int volumen { get; set; }
        public int tomo { get; set; }
        public int edition { get; set; }

        [StringLength(15)]
        public string cover { get; set; }

        [StringLength(250)]
        public string illustrations { get; set; }
        
        public int high { get; set; }
        public int width { get; set; }
        public int pages { get; set; }
        public int price { get; set; }

        [StringLength(150)]
        public string brings { get; set; }

        [StringLength(1500)]
        public string index { get; set; }
    }
}
