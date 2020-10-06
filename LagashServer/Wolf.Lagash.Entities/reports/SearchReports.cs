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
        public string text { get; set; }

        [StringLength(150)]
        public string options { get; set; }


        public DateTime date { get; set; }
    }
}
