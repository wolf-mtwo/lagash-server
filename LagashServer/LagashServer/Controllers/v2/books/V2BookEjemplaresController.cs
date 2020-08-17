using LagashServer.helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Wolf.Lagash.Entities;
using Wolf.Lagash.Entities.books;
using Wolf.Lagash.Interfaces;
using Wolf.Lagash.Services;

namespace LagashServer.Controllers.v2.books
{
    [Authorize]
    [RoutePrefix("v2/books")]
    public class V2BookEjemplaresController : ApiController
    {
        private IBookEjemplarService service = new BookEjemplarService(new LagashContext());

        [Route("{id}/ejemplares")]
        public IEnumerable<BookEjemplar> Get(string id)
        {
            return service.get_asc(o => o.material_id == id, o => o.order);
        }

        [Route("{id}/ejemplares")]
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
            return Ok(item);
        }
    }
}
