using System.ComponentModel.DataAnnotations;

namespace Wolf.Lagash.Entities.booking
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
        public string material_id { get; set; }
        
        [StringLength(36)]
        public string ejemplar_id { get; set; }

        [StringLength(36)]
        public string third_system { get; set; }

        [StringLength(36)]
        public string reader_id { get; set; }

        [StringLength(200)]
        public string state { get; set; }
    }
}
