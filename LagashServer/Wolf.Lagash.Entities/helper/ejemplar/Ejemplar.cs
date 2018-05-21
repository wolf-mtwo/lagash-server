﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolf.Lagash.Entities.helper.ejemplar
{
    public class Ejemplar
    {
        [Key]
        [StringLength(36)]
        public string _id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(50)]
        public string code { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(100)]
        public string inventory { get; set; }

        [Required]
        [StringLength(36)]
        public string data_id { get; set; }

        [Required]
        [StringLength(20)]
        public string type { get; set; }

        [Required]
        public int index { get; set; }

        [Required]
        public bool enabled { get; set; }

        [Required]
        public string state { get; set; }
    }
}