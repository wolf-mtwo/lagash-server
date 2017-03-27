using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolf.Lagash.Entities.map
{
    public class UserMap : Base
    {
        [Key]
        public int _id { get; set; }

        [Required]
        public int user_id { get; set; }

        [Required]
        public int library_id { get; set; }
    }
}
