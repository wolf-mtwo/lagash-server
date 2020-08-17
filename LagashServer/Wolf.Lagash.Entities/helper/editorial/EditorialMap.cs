using System.ComponentModel.DataAnnotations;

namespace Wolf.Lagash.Entities.helper.editorial
{
    public class EditorialMap : Base
    {
        [Key]
        [StringLength(36)]
        public string _id { get; set; }

        [Required]
        [StringLength(36)]
        public string editorial_id { get; set; }

        [Required]
        public string type { get; set; }

        [Required]
        public string material_id { get; set; }
    }
}
