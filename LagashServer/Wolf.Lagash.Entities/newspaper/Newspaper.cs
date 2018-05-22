using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolf.Lagash.Entities.newspaper
{
    public class Newspaper : Base
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

        [StringLength(50)]
        public string image { get; set; }
    }
}
