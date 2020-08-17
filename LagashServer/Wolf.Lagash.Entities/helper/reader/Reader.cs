using System.ComponentModel.DataAnnotations;

namespace Wolf.Lagash.Entities
{
    public class Reader : Base
    {
        [Key]
        [StringLength(36)]
        public string _id { get; set; }

        [StringLength(20)]
        public string first_name { get; set; }

        [StringLength(100)]
        public string last_name { get; set; }

        [StringLength(25)]
        public string card_type { get; set; }

        [StringLength(36)]
        public string card_id { get; set; }

        [StringLength(50)]
        public string image { get; set; }

        [StringLength(50)]
        public string auth_type { get; set; }

        [StringLength(36)]
        public string faculty_id { get; set; }

        [StringLength(36)]
        public string career_id { get; set; }

        [StringLength(10)]
        public string semester { get; set; }

        [Required]
        public bool enabled { get; set; }
    }
}
