using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace LagashServer.helper
{
    public class EncryptPassword
    {
        public string EncodePassword(string password)
        {
            byte[] inArray = HashAlgorithm.Create("SHA1")
                .ComputeHash(Encoding.Unicode.GetBytes(password));
            return Convert.ToBase64String(inArray);
        }
    }
    
}