using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolf.Lagash.Entities
{
    public class BookCatalog : Base
    {
        [Key]
        public int _id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }
    }
}
