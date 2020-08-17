using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wolf.Lagash.Entities.helper.author
{
    public class Author : Base
    {
        [Key]
        [StringLength(36)]
        public string _id { get; set; }

        [StringLength(50)]
        public string code { get; set; }

        [StringLength(100)]
        public string first_name { get; set; }

        [StringLength(100)]
        public string last_name { get; set; }

        [StringLength(100)]
        public string country { get; set; }

        [StringLength(50)]
        public string image { get; set; }

        [NotMapped]
        public AuthorMap map { get; set; }
    }
}
