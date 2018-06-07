using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolf.Lagash.Entities.helper;

namespace Wolf.Lagash.Entities.books
{
    public class Booking : Base
    {
        [Key]
        [StringLength(36)]
        public string _id { get; set; }

        [StringLength(50)]
        public string code { get; set; }

        [StringLength(36)]
        public string type { get; set; }

        [StringLength(36)]
        public string data_id { get; set; }
        
        [StringLength(36)]
        public string ejemplar_id { get; set; }

        [StringLength(36)]
        public string user_id { get; set; }

        [StringLength(36)]
        public string third_system { get; set; }

        [StringLength(200)]
        public string name { get; set; }

        [StringLength(200)]
        public string state { get; set; }

        [StringLength(36)]
        public string information { get; set; }
    }
}
