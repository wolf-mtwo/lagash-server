using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolf.Lagash.Entities
{
    public class ThesisCatalog : Base
    {
        [Key]
        public string _id { get; set; }

        [Required]
        [StringLength(50)]
        public string title { get; set; }
        
        [Required]
        public bool enabled { get; set; }
    }
}
