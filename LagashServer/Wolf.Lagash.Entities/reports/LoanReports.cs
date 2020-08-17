using System;
using System.ComponentModel.DataAnnotations;
s
namespace Wolf.Lagash.Entities.reports
{
    public class LoanReports : Base
    {
        [StringLength(36)]
        public string reader_id { get; set; }

        [StringLength(36)]
        public string resource_id { get; set; }

        [StringLength(36)]
        public string resoruce_type{ get; set; }

        [StringLength(36)]
        public string ejemplar_id { get; set; }

        [StringLength(36)]
        public string facultad_id { get; set; }

        [StringLength(36)]
        public string career_id { get; set; }

        public DateTime start_date { get; set; }

        public DateTime end_date { get; set; }
    }
}
