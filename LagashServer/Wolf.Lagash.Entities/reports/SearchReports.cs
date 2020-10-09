using System;
using System.ComponentModel.DataAnnotations;

namespace Wolf.Lagash.Entities.reports
{
    public class SearchReports : Base
    {
        [Key]
        [StringLength(36)]
        public string _id { get; set; }

        [StringLength(36)]
        public string reader_id { get; set; }

        [StringLength(200)]
        public string search { get; set; }

        [StringLength(200)]
        public string options { get; set; }
    }
}
