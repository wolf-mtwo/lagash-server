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
        [StringLength(250)]
        public string title { get; set; }
        
        [Required]
        [StringLength(250)]
        public string description { get; set; }
        
        [StringLength(1000)]
        public string index { get; set; }

        [Required]
        public bool enabled { get; set; }

        [Required]
        public string state { get; set; }

        public string catalog_id { get; set; }
    }
}
