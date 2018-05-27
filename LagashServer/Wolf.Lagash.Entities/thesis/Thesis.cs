using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolf.Lagash.Entities
{
    public class Thesis : Base
    {
        [Key]
        [StringLength(36)]
        public string _id { get; set; }

        [Required]
        public bool enabled { get; set; }

        [Required]
        [StringLength(250)]
        public string title { get; set; }

        [StringLength(250)]
        public string tags { get; set; }

        [StringLength(36)]
        public string catalog_id { get; set; }

        [StringLength(36)]
        public string tutor_id { get; set; }

        [StringLength(36)]
        public string carrer_id { get; set; }

        // autors

        // optative
        [StringLength(15)]
        public string cover { get; set; }

        [StringLength(250)]
        public string illustrations { get; set; }

        public int length { get; set; }
        public int width { get; set; }
        public int pages { get; set; }
        public int year { get; set; }
        public int price { get; set; }

        [StringLength(150)]
        public string brings { get; set; }
        
        [StringLength(1000)]
        public string index { get; set; }

        [StringLength(50)]
        public string image { get; set; }
    }
}
