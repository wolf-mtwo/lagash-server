using System.ComponentModel.DataAnnotations;

namespace Wolf.Lagash.Entities.map
{
    public class UserMap : Base
    {
        [Key]
        public int _id { get; set; }

        [Required]
        public int user_id { get; set; }

        [Required]
        public int library_id { get; set; }
    }
}
