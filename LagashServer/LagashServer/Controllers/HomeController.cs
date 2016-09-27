using LagashServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LagashServer.Controllers
{
    public class HomeController : ApiController
    {
        private SchoolContext db = new SchoolContext();

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            //return new string[] { "value1", "value2" };
            db.Students.Add(new Student { FirstMidName = "Yan", LastName = "Anand", EnrollmentDate = DateTime.Parse("2003-09-01") });
            
            List<Student> list = db.Students.ToList();
            db.SaveChanges();
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}