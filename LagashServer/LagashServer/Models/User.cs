using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LagashServer.Models
{
    public class User
    {
        private int _id;
        public string name { get; set; }
        public string password { get; set; }
        public string cel { get; set; }
        public string email { get; set; }
        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }
    }
}