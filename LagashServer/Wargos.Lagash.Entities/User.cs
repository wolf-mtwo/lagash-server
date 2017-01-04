using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wargos.Lagash.Entities
{
    public class User
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int _id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public string cel { get; set; }

        [Required]
        public string email { get; set; }
    }
}