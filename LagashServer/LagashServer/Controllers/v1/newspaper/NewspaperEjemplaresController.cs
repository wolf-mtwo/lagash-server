using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Web.Http;
using LagashServer.helper;
using Wolf.Lagash.Entities.helper.ejemplar;
using LagashServer.Controllers.helpers;
using Wolf.Lagash.Entities.newspaper;
using Wolf.Lagash.Services.newspaper;
using Wolf.Lagash.Interfaces.newspaper;

namespace LagashServer.Controllers.v1.newspaper
{
    [Authorize]
    [RoutePrefix("v1/newspaper/ejemplares")]
    public class NewspaperEjemplaresController : ApiController
    {
        private INewspaperEjemplarService service = new NewspaperEjemplarService(new LagashContext());

        [Route("")]
        public IEnumerable<NewspaperEjemplar> Get()
        {
            return service.GetAll();
        }

        [Route("")]
        public IHttpActionResult Post(NewspaperEjemplar item)
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
        public IHttpActionResult Get(string id)
        {
            NewspaperEjemplar item = service.FindById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            NewspaperEjemplar item = service.FindById(id);
            if (item == null)
            {
                return NotFound();
            }
            service.Delete(item);
            service.Commit();
            return Ok(item);
        }

        [Route("{id}")]
        public IHttpActionResult Put(string id, NewspaperEjemplar item)
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
        public IEnumerable<NewspaperEjemplar> Get(int page, int limit)
        {
            return service.GetPage(page, limit, o => o.inventory);
        }

        [Route("page/{page}/limit/{limit}/search")]
        public IEnumerable<NewspaperEjemplar> GetFind(int page, int limit, string search)
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
        public IEnumerable<NewspaperEjemplar> GetSelect(int start, int end)
        {
            return service.select(start, end);
        }
    }
}