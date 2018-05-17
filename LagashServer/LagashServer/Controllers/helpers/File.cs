using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LagashServer.Controllers.helpers
{
    public class File
    {
        public String name { get; set; }

        public File(string name)
        {
            this.name = name;
        }
    }
}