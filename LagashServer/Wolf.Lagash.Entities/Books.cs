using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolf.Lagash.Entities
{
    public class Books
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
    }
}
