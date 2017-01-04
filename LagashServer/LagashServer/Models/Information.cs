using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LagashServer.Models
{
    public class Information
    {
        public string version { get; set; }
        public DateTime uptime { get; set; }

        public Information(string version)
        {
            this.version = version;
            this.uptime = DateTime.Now;
        }
    }
}