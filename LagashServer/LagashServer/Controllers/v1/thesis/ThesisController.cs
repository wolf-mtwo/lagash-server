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
    [RoutePrefix("v1/thesis")]
    public class ThesisController : ApiController
    {
        private IThesisService service = new ThesisService(new LagashContext());

        public IEnumerable<Thesis> Get()
        {
            return service.GetAll();
        }

        [ResponseType(typeof(Thesis))]
        public IHttpActionResult Post(Thesis item)
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

        [ResponseType(typeof(Thesis))]
        public IHttpActionResult Get(String id)
        {
            Thesis item = service.FindById(id);
            if (item == null) {
                return NotFound();
            }

            return Ok(item);
        }

        [ResponseType(typeof(Thesis))]
        public IHttpActionResult Delete(String id)
        {
            Thesis item = service.FindById(id);
            if (item == null) {
                return NotFound();
            }
            service.Delete(item);
            service.Commit();

            return Ok(item);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Put(String id, Thesis item)
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