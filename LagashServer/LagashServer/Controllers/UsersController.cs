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
using Wargos.Lagash.Services;
using Wargos.Lagash.Entities;
using Wargos.Lagash.Interfaces;
using LagashServer.helper;

namespace LagashServer.Controllers
{
    public class UsersController : ApiController
    {
        private IUserService service = new UserService(new LagashContext());

        // GET: api/users
        public IQueryable<User> Getusers()
        {
            return service.GetAll1();
        }

        // POST: api/users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            service.Create(user);
            service.Commit();

            return CreatedAtRoute("DefaultApi", new { id = user._id }, user);
        }

        // GET: api/users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = service.FindById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // DELETE: api/users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = service.FindById(id);
            if (user == null)
            {
                return NotFound();
            }
            service.Delete(user);
            service.Commit();

            return Ok(user);
        }

        // PUT: api/users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user._id)
            {
                return BadRequest();
            }

            service.Update(user);

            try
            {
                service.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!service.userExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(user);
        }
    }
}