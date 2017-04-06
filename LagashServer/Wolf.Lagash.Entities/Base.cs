using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolf.Lagash.Entities
{
    public class Base
    {
        public Base()
        {
            created = DateTime.Now;
        }

        [Required]
        public DateTime created { get; set; }
    }
}
