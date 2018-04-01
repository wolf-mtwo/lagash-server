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

namespace LagashServer.Controllers.v1.books
{
    public class MagazineCatalogsController : ApiController
    {
        private IMagazineCatalogService service = new MagazineCatalogService(new LagashContext());

        public IEnumerable<MagazineCatalog> Get()
        {
            return service.GetAll();
        }

        [ResponseType(typeof(MagazineCatalog))]
        public IHttpActionResult Post(MagazineCatalog item)
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

        [ResponseType(typeof(MagazineCatalog))]
        public IHttpActionResult Get(int id)
        {
            MagazineCatalog item = service.FindById(id);
            if (item == null) {
                return NotFound();
            }

            return Ok(item);
        }

        [ResponseType(typeof(MagazineCatalog))]
        public IHttpActionResult Delete(int id)
        {
            MagazineCatalog item = service.FindById(id);
            if (item == null) {
                return NotFound();
            }
            service.Delete(item);
            service.Commit();

            return Ok(item);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, MagazineCatalog item)
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