using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolf.Lagash.Entities
{
    public class EditorialMap : Base
    {
        [Key]
        [StringLength(36)]
        public string _id { get; set; }

        [Required]
        [StringLength(36)]
        public string editorial_id { get; set; }

        [Required]
        public string type { get; set; }

        [Required]
        public string resource_id { get; set; }
    }
}
