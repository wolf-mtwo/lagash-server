using System.ComponentModel.DataAnnotations;

namespace Wolf.Lagash.Entities.helper.author
{
    public class AuthorMap : Base
    {
        [Key]
        [StringLength(36)]
        public string _id { get; set; }

        [Required]
        [StringLength(36)]
        public string author_id { get; set; }

        [Required]
        [StringLength(10)]
        public string type { get; set; }

        [Required]
        [StringLength(36)]
        public string material_id { get; set; }
    }
}
