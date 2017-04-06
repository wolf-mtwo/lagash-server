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
    //[RoutePrefix("v1/books")]
    public class BooksController : ApiController
    {
        private IBooksService service = new BooksService(new LagashContext());

        public IEnumerable<Book> Get()
        {
            return service.GetAll();
        }

        [ResponseType(typeof(Book))]
        public IHttpActionResult Post(Book item)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            try {
                service.Create(item);
                service.Commit();
            } catch (Exception e) {
                return new LagashActionResult(e.Message);
            }

            return CreatedAtRoute("DefaultApi", new { id = item._id }, item);
        }

        [ResponseType(typeof(Book))]
        public IHttpActionResult Get(String id)
        {
            Book item = service.FindById(id);
            if (item == null) {
                return NotFound();
            }

            return Ok(item);
        }

        [ResponseType(typeof(Book))]
        public IHttpActionResult Delete(String id)
        {
            Book item = service.FindById(id);
            if (item == null) {
                return NotFound();
            }
            service.Delete(item);
            service.Commit();

            return Ok(item);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Put(String id, Book item)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (id != item._id) {
                return new LagashActionResult("should provide a valid _id");
            }

            service.Update(item);

            try {
                service.Commit();
            } catch (DbUpdateConcurrencyException) {
                if (!service.exists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return Ok(item);
        }
    }
}