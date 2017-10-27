using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolf.Lagash.Entities.map
{
    public class AuthorMap : Base
    {
        [Key]
        public int _id { get; set; }

        [Required]
        public int book_id { get; set; }

        [Required]
        public int author_id { get; set; }
    }
}
