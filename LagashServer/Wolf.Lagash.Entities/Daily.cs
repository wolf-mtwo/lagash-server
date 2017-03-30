using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolf.Lagash.Entities
{
    public class Daily
    {
        [Key]
        [StringLength(36)]
        public string _id { get; set; }

        [Required]
        public DateTime date { get; set; }

        [Required]
        public int news_id { get; set; }
        
        [Required]
        public bool enabled { get; set; }

        [Required]
        public BookStates state { get; set; }
    }
}
