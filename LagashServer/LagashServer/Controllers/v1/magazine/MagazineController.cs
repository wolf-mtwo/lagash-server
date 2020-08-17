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
using Wolf.Lagash.Entities;
using LagashServer.helper;
using Wolf.Lagash.Entities.books;
using LagashServer.Controllers.helpers;
using Wolf.Lagash.Entities.magazine;
using Wolf.Lagash.Services.magazine;
using Wolf.Lagash.Interfaces.magazine;

namespace LagashServer.Controllers.v1.books
{
    [Authorize]
    [RoutePrefix("v1/magazines")]
    public class MagazineController : ApiController
    {
        private IMagazineService service = new MagazineService(new LagashContext());

        [Route("")]
        public IEnumerable<Magazine> Get()
        {
            return service.GetAll();
        }

        [Route("")]
        public IHttpActionResult Post(Magazine item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                service.Create(item);
                service.Commit();
            }
            catch (Exception e)
            {
                return new LagashActionResult(e.Message);
            }
            return Ok(item);
        }

        [Route("{id}")]
        public IHttpActionResult Get(String id)
        {
            Magazine item = service.FindById(id);
            if (item == null) {
                return NotFound();
            }
            return Ok(item);
        }

        [Route("{id}")]
        public IHttpActionResult Delete(String id)
        {
            Magazine item = service.FindById(id);
            if (item == null) {
                return NotFound();
            }
            service.Delete(item);
            service.Commit();
            return Ok(item);
        }

        [Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(String id, Magazine item)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            if (id != item._id) {
                return new LagashActionResult("should provide a valid _id");
            }
            
            try {
                Magazine ejemplar = service.FindOne(o => o.code_material == item.code_material);
                if (ejemplar != null && ejemplar._id != id)
                {
                    return new LagashActionResult("El codigo ya esta registrado");
                }
                service.discart(ejemplar);
                service.Update(item);
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

        [Route("page/{page}/limit/{limit}")]
        public IEnumerable<Magazine> Get(int page, int limit)
        {
            return service.GetPage(page, limit, o => o.created);
        }
        
        [Route("page/{page}/limit/{limit}/search")]
        public IEnumerable<Magazine> GetFind(int page, int limit, string search)
        {
            if (search == null) search = "";
            return service.Where(page, limit, (o) => {
                return o.title.ToLower().Contains(search.ToLower());
            }, o => o.created);
        }

        [Route("size")]
        public Size GetSize()
        {
            return new Size()
            {
                total = service.Count()
            };
        }

        [Route("catalog/{id}/page/{page}/limit/{limit}")]
        public IEnumerable<Magazine> GetItems(string id, int page, int limit, string search)
        {
            if (search == null) search = "";
            return service.Where(page, limit, (o) => {
                return o.catalog_id != null && o.catalog_id.Equals(id) && o.title.ToLower().Contains(search.ToLower());
            }, o => o.created);
        }
    }
}