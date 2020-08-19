using System;

namespace LagashServer.Controllers.helpers
{
    public class Information
    {
        public string version { get; set; }
        public DateTime uptime { get; set; }

        public Information(string version)
        {
            this.version = version;
            uptime = DateTime.Now;
        }
    }
}