using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolf.Lagash.Entities
{
    public class News : Base
    {
        [Key]
        public int _id { get; set; }

        [Required]
        public string title { get; set; }

        [Required]
        public bool enabled { get; set; }
    }
}
