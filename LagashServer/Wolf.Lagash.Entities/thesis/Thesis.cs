using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolf.Lagash.Entities.helper;

namespace Wolf.Lagash.Entities
{
    public class Thesis : Material
    {
        [StringLength(36)]
        public string tutor_id { get; set; }
        
        [StringLength(36)]
        public string faculty_id { get; set; }

        [StringLength(36)]
        public string carrera_id { get; set; }

        [StringLength(15)]
        public string cover { get; set; }

        [StringLength(25)]
        public string category { get; set; }

        //[StringLength(250)]
        //public string illustrations { get; set; }

        //public int high { get; set; }
        //public int width { get; set; }
        public int pages { get; set; }
        public int price { get; set; }

        //[StringLength(150)]
        //public string brings { get; set; }
        
        [StringLength(1500)]
        public string index { get; set; }
    }
}
