using System;

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