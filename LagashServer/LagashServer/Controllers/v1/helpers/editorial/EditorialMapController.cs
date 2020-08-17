using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Web.Http;
using LagashServer.helper;
using LagashServer.Controllers.helpers;
using Wolf.Lagash.Entities.helper.editorial;
using Wolf.Lagash.Services.helpers.editorial;
using Wolf.Lagash.Interfaces.helpers.editorial;

namespace LagashServer.Controllers.v1.helpers.editorial
{
    [Authorize]
    [RoutePrefix("v1/editorial-map")]
    public class EditorialMapController : ApiController
    {
        private IEditorialMapService service = new EditorialMapService(new LagashContext());

        [Route("")]
        public IEnumerable<EditorialMap> Get()
        {
            return service.GetAll();
        }

        [Route("")]
        public IHttpActionResult Post(EditorialMap item)
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
            EditorialMap item = service.FindById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            EditorialMap item = service.FindById(id);
            if (item == null)
            {
                return NotFound();
            }
            service.Delete(item);
            service.Commit();
            return Ok(item);
        }

        [Route("{id}")]
        public IHttpActionResult Put(string id, EditorialMap item)
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
        public IEnumerable<EditorialMap> Get(int page, int limit)
        {
            return service.GetPage(page, limit, o => o.created);
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