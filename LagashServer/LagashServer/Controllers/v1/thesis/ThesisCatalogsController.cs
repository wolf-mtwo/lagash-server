using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Web.Http;
using LagashServer.helper;
using LagashServer.Controllers.helpers;
using Wolf.Lagash.Entities.thesis;
using Wolf.Lagash.Services.thesis;
using Wolf.Lagash.Interfaces.thesis;

namespace LagashServer.Controllers.v1.thesis
{
    [Authorize]
    [RoutePrefix("v2/thesis/catalogs")]
    public class ThesisCatalogsController : ApiController
    {
        private IThesisCatalogService service = new ThesisCatalogService(new LagashContext());

        [Route("")]
        public IEnumerable<ThesisCatalog> Get()
        {
            return service.GetAll();
        }

        [Route("")]
        public IHttpActionResult Post(ThesisCatalog item)
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
            ThesisCatalog item = service.FindById(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            ThesisCatalog item = service.FindById(id);
            if (item == null)
            {
                return NotFound();
            }
            service.Delete(item);
            service.Commit();

            return Ok(item);
        }

        [Route("{id}")]
        public IHttpActionResult Put(string id, ThesisCatalog item)
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
        public IEnumerable<ThesisCatalog> Get(int page, int limit)
        {
            return service.GetPage(page, limit, o => o.created);
        }

        [Route("page/{page}/limit/{limit}/search")]
        public IEnumerable<ThesisCatalog> GetFind(int page, int limit, string search)
        {
            if (search == null) search = "";
            return service.Where(page, limit, (o) =>
            {
                return o.title.Contains(search) || o._id.Contains(search);
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
    }
}