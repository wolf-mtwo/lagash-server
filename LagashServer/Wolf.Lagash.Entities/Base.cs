using System;
using System.ComponentModel.DataAnnotations;

namespace Wolf.Lagash.Entities
{
    public class Base
    {
        public Base()
        {
            created = DateTime.Now;
        }

        [Required]
        public DateTime created { get; set; }
    }
}
