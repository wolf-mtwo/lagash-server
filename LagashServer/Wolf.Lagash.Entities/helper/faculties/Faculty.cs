using System.ComponentModel.DataAnnotations;

namespace Wolf.Lagash.Entities.helper.faculties
{
    public class Faculty : Base
    {
        [Key]
        [StringLength(36)]
        public string _id { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [StringLength(50)]
        public string image { get; set; }
    }
}
