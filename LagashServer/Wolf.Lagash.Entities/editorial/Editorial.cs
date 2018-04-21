using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolf.Lagash.Entities
{
    public class Editorial : Base
    {
        [Key]
        [StringLength(36)]
        public string _id { get; set; }

        [StringLength(100)]
        public string nombre { get; set; }

        [StringLength(50)]
        public string country { get; set; }

        [StringLength(50)]
        public string city { get; set; }
    }
}
