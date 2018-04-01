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
using Wolf.Lagash.Entities.books;

namespace LagashServer.Controllers.v1.books
{
    [RoutePrefix("v1/ejemplares")]
    public class BookEjemplaresController : ApiController
    {
        private IBookEjemplarService service = new BookEjemplarService(new LagashContext());

        public IEnumerable<BookEjemplar> Get()
        {
            return service.GetAll();
        }

        [ResponseType(typeof(BookEjemplar))]
        public IHttpActionResult Post(BookEjemplar item)
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

        [Route("{id}")]
        [ResponseType(typeof(Book))]
        public IHttpActionResult Get(String id)
        {
            BookEjemplar item = service.FindById(id);
            if (item == null) {
                return NotFound();
            }
            return Ok(item);
        }

        [ResponseType(typeof(Book))]
        public IHttpActionResult Delete(String id)
        {
            BookEjemplar item = service.FindById(id);
            if (item == null) {
                return NotFound();
            }
            service.Delete(item);
            service.Commit();
            return Ok(item);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Put(String id, BookEjemplar item)
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