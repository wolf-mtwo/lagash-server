using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolf.Lagash.Entities
{
    public class Book
    {
        [Key]
        public int _id { get; set; }

        [Required]
        [StringLength(100)]
        public string inventory { get; set; }

        [Required]
        [StringLength(50)]
        public string code { get; set; }

        [Required]
        [StringLength(36)]
        public string uuid { get; set; }

        [Required]
        [StringLength(250)]
        public string titulo { get; set; }

        [Required]
        [StringLength(20)]
        public string ISBN { get; set; }

        [Required]
        public bool enabled { get; set; }

        [Required]
        public string description { get; set; }

        // autors
        // specimen

        // optative
        public string valumen { get; set; }
        public string tome { get; set; }
        public string pages { get; set; }
        public string editorial { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        //public string ISBN { get; set; }
        public string brings { get; set; }
        public string year { get; set; }
        public string type { get; set; }
        public string illustration { get; set; }
        public string size { get; set; }
        public string index { get; set; }
    }
}
