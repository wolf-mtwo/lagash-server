using System.ComponentModel.DataAnnotations;

namespace Wolf.Lagash.Entities.magazine
{
    public class MagazineCatalog : Base
    {
        [Key]
        public string _id { get; set; }

        [Required]
        [StringLength(50)]
        public string title { get; set; }

        [Required]
        public bool enabled { get; set; }
    }
}
