using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolf.Lagash.Entities.books
{
    public class Book : Base
    {
        //[Key]
        //public int _id { get; set; }

        [Key]
        //[Required]
        [StringLength(36)]
        //public string uuid { get; set; }
        public string _id { get; set; }
        
        [Required]
        [StringLength(250)]
        public string title { get; set; }

        [Required]
        [StringLength(20)]
        public string isbn { get; set; }

        [Required]
        public bool enabled { get; set; }

        [Required]
        [StringLength(250)]
        public string description { get; set; }

        public string state_catalog_id { get; set; }
        // autors
        // specimen

        // optative
        [StringLength(10)]
        public string volumen { get; set; }

        [StringLength(10)]
        public string tome { get; set; }

        public int pages { get; set; }

        [StringLength(100)]
        public string editorial { get; set; }

        [StringLength(50)]
        public string country { get; set; }

        [StringLength(50)]
        public string city { get; set; }

        [StringLength(100)]
        public string brings { get; set; }

        public int year { get; set; }

        [StringLength(50)]
        public string type { get; set; }
        
        [StringLength(100)]
        public string illustration { get; set; }

        [StringLength(20)]
        public string size { get; set; }

        [StringLength(1000)]
        public string index { get; set; }
    }
}
