using System.ComponentModel.DataAnnotations;

namespace Wolf.Lagash.Entities.helper
{
    public class Material : Base
    {
        [Key]
        [StringLength(36)]
        public string _id { get; set; }

        [Required]
        [StringLength(300)]
        public string title { get; set; }

        [Required]
        [StringLength(50)]
        public string code_material { get; set; }

        [Required]
        [StringLength(50)]
        public string code_author { get; set; }

        [StringLength(500)]
        public string tags { get; set; }

        [StringLength(36)]
        public string catalog_id { get; set; }

        [StringLength(36)]
        public string editorial_id { get; set; }

        [StringLength(50)]
        public string image { get; set; }

        [Required]
        public bool enabled { get; set; }

        public int year { get; set; }
    }
}
