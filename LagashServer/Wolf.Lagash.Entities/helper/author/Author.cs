using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolf.Lagash.Entities.map;

namespace Wolf.Lagash.Entities
{
    public class Author : Base
    {
        [Key]
        [StringLength(36)]
        public string _id { get; set; }

        //[Required]
        //[Index(IsUnique = true)]
        [StringLength(50)]
        public string code { get; set; }

        [StringLength(100)]
        public string first_name { get; set; }

        [StringLength(100)]
        public string last_name { get; set; }

        [StringLength(100)]
        public string country { get; set; }

        [NotMapped]
        public AuthorMap map { get; set; }
    }
}
