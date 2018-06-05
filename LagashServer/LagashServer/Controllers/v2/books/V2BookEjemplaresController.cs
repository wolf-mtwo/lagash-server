using LagashServer.helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Wolf.Lagash.Entities;
using Wolf.Lagash.Interfaces;
using Wolf.Lagash.Services;

namespace LagashServer.Controllers.v2.books
{
    [RoutePrefix("v2/books")]
    public class V2BookEjemplaresController : ApiController
    {
        private IBookEjemplarService service = new BookEjemplarService(new LagashContext());

        [Route("{id}/ejemplares")]
        public IEnumerable<BookEjemplar> Get(string id)
        {
            return service.Query(o => o.data_id == id);
        }

        [Route("{id}/ejemplares")]
        public IHttpActionResult Post(BookEjemplar item)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            try {
                BookEjemplar ejemplar = service.FindOne(o => o.code == item.code);
                if (ejemplar != null) {
                    return new LagashActionResult("La signatura topográfica ya existe");
                }
                service.Create(item);
                service.Commit();
            } catch (Exception e) {
                return new LagashActionResult(e.Message);
            }
            return Ok(item);
        }
    }
}
