using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Wolf.Lagash.Services;
using Wolf.Lagash.Entities;
using Wolf.Lagash.Interfaces;
using LagashServer.helper;

namespace LagashServer.Controllers
{
    [RoutePrefix("p1/users")]
    public class UsersController : ApiController
    {
        private IUsersService service = new UsersService(new LagashContext());

        [Route("")]
        public IEnumerable<User> Get()
        {
            return service.GetAll();
        }

        [Route("")]
        [ResponseType(typeof(User))]
        public IHttpActionResult Post(User item)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            try {
                service.CreateUser(item);
                service.Commit();
            } catch (Exception e) {
                return new LagashActionResult(e.Message);
            }

            return CreatedAtRoute("DefaultApi", new { id = item._id }, item);
        }

        [Route("{id}")]
        [ResponseType(typeof(User))]
        public IHttpActionResult Get(int id)
        {
            User user = service.FindById(id);
            if (user == null) {
                return NotFound();
            }
            return Ok(user);
        }

        [Route("{id}")]
        [ResponseType(typeof(User))]
        public IHttpActionResult Delete(int id)
        {
            User user = service.FindById(id);
            if (user == null) {
                return NotFound();
            }
            service.Delete(user);
            service.Commit();
            return Ok(user);
        }

        [Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, User user)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            if (id != user._id) {
                return new LagashActionResult("should provide a valid _id");
            }
            service.Update(user);
            try {
                service.Commit();
            } catch (DbUpdateConcurrencyException) {
                if (!service.userExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }
            return Ok(user);
        }
    }
}