using System.ComponentModel.DataAnnotations;
using Wolf.Lagash.Entities.helper;

namespace Wolf.Lagash.Entities.thesis
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

        public int pages { get; set; }
        public int price { get; set; }
        
        [StringLength(1500)]
        public string index { get; set; }
    }
}
