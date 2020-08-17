using System;
using System.ComponentModel.DataAnnotations;

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

    }
}
