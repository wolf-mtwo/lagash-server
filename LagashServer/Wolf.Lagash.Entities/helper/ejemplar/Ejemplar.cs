using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wolf.Lagash.Entities.helper.ejemplar
{
    public class Ejemplar : Base
    {
        [Key]
        [StringLength(36)]
        public string _id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public int inventory { get; set; }

        [Required]
        [StringLength(36)]
        public string material_id { get; set; }

        [Required]
        public int order { get; set; }

        [Required]
        public bool enabled { get; set; }

        [Required]
        public string state { get; set; }

        [StringLength(10)]
        public string suffix { get; set; }
    }
}
