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
using Wolf.Lagash.Entities.helper.editorial;
using Wolf.Lagash.Services.helpers.editorial;
using Wolf.Lagash.Interfaces.helpers.editorial;

namespace LagashServer.Controllers.v1.books
{
    [Authorize]
    [RoutePrefix("v1/editorials")]
    public class EditorialController : ApiController
    {
        private IEditorialService service = new EditorialService(new LagashContext());
        private IEditorialMapService service_map = new EditorialMapService(new LagashContext());

        [Route("")]
        public IEnumerable<Editorial> Get()
        {
            return service.GetAll();
        }

        [Route("")]
        public IHttpActionResult Post(Editorial item)
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
            return Ok(item);
        }

        [Route("{id}")]
        public IHttpActionResult Get(String id)
        {
            Editorial item = service.FindById(id);
            if (item == null) {
                return NotFound();
            }
            return Ok(item);
        }

        [Route("{id}")]
        public IHttpActionResult Delete(String id)
        {
            Editorial item = service.FindById(id);
            if (item == null) {
                return NotFound();
            }
            service.Delete(item);
            service.Commit();
            return Ok(item);
        }

        [Route("{id}")]
        public IHttpActionResult Put(String id, Editorial item)
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

        [Route("page/{page}/limit/{limit}/search")]
        public IEnumerable<Editorial> GetFind(int page, int limit, string search)
        {
            if (search == null) search = "";
            return service.Where(page, limit, (u) => u.name != null && u.name.ToLower().Contains(search.ToLower()), o => o.created);
        }

        [Route("page/{page}/limit/{limit}")]
        public IEnumerable<Editorial> Get(int page, int limit)
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

        [Route("find")]
        public IEnumerable<Editorial> GetFind(string material_id)
        {
            IEnumerable<EditorialMap> items = service_map.Query(o => o.material_id == material_id);
            List<Editorial> result = new List<Editorial>();
            foreach (var item in items) {
                Editorial editorial = service.FindById(item.editorial_id);
                editorial.map = item;
                result.Add(editorial);
            }
            return result;
        }
    }
}