using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wolf.Lagash.Entities
{
    public class User : Base
    {
        [Key]
        [StringLength(36)]
        public string _id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        [Required]
        [StringLength(15)]
        public string cel { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(100)]
        public string email { get; set; }

        [NotMapped]
        public Token token { get; set; }
    }

    public class Token
    {
        public string session_id { get; set; }
    }

    public class Login
    {
        [Required(ErrorMessage = "El password no puede ser vacio")]
        public string password { get; set; }

        [Required(ErrorMessage = "El email no puede ser vacio")]
        public string email { get; set; }
    }
}