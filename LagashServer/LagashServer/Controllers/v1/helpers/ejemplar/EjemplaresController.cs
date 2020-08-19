using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Web.Http;
using LagashServer.helper;
using Wolf.Lagash.Entities.helper.ejemplar;
using LagashServer.Controllers.helpers;
using Wolf.Lagash.Services.helpers.ejemplar;
using Wolf.Lagash.Interfaces.helpers.ejemplar;

namespace LagashServer.Controllers.v1.helpers.ejemplar
{
    [Authorize]
    [RoutePrefix("v1/ejemplares")]
    public class EjemplaresController : ApiController
    {
        private IEjemplarService service = new EjemplarService(new LagashContext());

        [Route("")]
        public IEnumerable<Ejemplar> Get()
        {
            return service.GetAll();
        }

        [Route("")]
        public IHttpActionResult Post(Ejemplar item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                //Ejemplar ejemplar = service.FindOne(o => o.code == item.code);
                //if (ejemplar != null) {
                //    return new LagashActionResult("La signatura topográfica ya existe");
                //}
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
        public IHttpActionResult Get(string id)
        {
            Ejemplar item = service.FindById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            Ejemplar item = service.FindById(id);
            if (item == null)
            {
                return NotFound();
            }
            service.Delete(item);
            service.Commit();
            return Ok(item);
        }

        [Route("{id}")]
        public IHttpActionResult Put(string id, Ejemplar item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != item._id)
            {
                return new LagashActionResult("should provide a valid _id");
            }
            service.Update(item);
            try
            {
                service.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!service.exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(item);
        }

        [Route("page/{page}/limit/{limit}")]
        public IEnumerable<Ejemplar> Get(int page, int limit)
        {
            return service.GetPage(page, limit, o => o.inventory);
        }

        [Route("page/{page}/limit/{limit}/search")]
        public IEnumerable<Ejemplar> GetFind(int page, int limit, string search)
        {
            if (search == null) search = "";
            return service.Where(page, limit, (o) =>
            {
                return o.inventory.ToString().Contains(search) || o._id.Contains(search);
            }, o => o.inventory);
        }

        [Route("size")]
        public Size GetSize()
        {
            return new Size()
            {
                total = service.Count()
            };
        }

        [Route("next")]
        public Ejemplar GetNext()
        {
            return service.next();
        }

        [Route("select")]
        public IEnumerable<Ejemplar> GetSelect(int start, int end)
        {
            return service.select(start, end);
        }
    }
}