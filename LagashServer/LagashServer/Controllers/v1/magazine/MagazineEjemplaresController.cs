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
    public class MagazineEjemplaresController : ApiController
    {
        private IMagazineEjemplarService service = new MagazineEjemplarService(new LagashContext());

        public IEnumerable<MagazineEjemplar> Get()
        {
            return service.GetAll();
        }

        [ResponseType(typeof(MagazineEjemplar))]
        public IHttpActionResult Post(MagazineEjemplar item)
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

        [ResponseType(typeof(MagazineEjemplar))]
        public IHttpActionResult Get(String id)
        {
            MagazineEjemplar item = service.FindById(id);
            if (item == null) {
                return NotFound();
            }
            return Ok(item);
        }

        [ResponseType(typeof(MagazineEjemplar))]
        public IHttpActionResult Delete(String id)
        {
            MagazineEjemplar item = service.FindById(id);
            if (item == null) {
                return NotFound();
            }
            service.Delete(item);
            service.Commit();
            return Ok(item);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Put(String id, MagazineEjemplar item)
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