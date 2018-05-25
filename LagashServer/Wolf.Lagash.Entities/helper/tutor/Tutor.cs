using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolf.Lagash.Entities.map;

namespace Wolf.Lagash.Entities.tutor
{
    public class Tutor : Base
    {
        [Key]
        [StringLength(36)]
        public string _id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string first_name { get; set; }

        [Required]
        [StringLength(100)]
        public string last_name { get; set; }

        [StringLength(100)]
        public string degree { get; set; }

        [StringLength(100)]
        public string country { get; set; }
        
        [NotMapped]
        public AuthorMap map { get; set; }
    }
}
