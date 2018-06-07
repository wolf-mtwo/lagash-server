using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LagashServer.Controllers.helpers
{
    public class Loan
    {
        public string _id { get; set; }
        public string type { get; set; }
        public string data_id { get; set; }
        public string ejemplar_id { get; set; }
        public string state { get; set; }
    }
}