using LagashServer.helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Wolf.Lagash.Entities;
using Wolf.Lagash.Entities.history;
using Wolf.Lagash.Interfaces;
using Wolf.Lagash.Interfaces.history;
using Wolf.Lagash.Services;
using Wolf.Lagash.Services.history;

namespace LagashServer.Controllers.v2.history
{
    [RoutePrefix("v2/resource")]
    public class V2EjemplaresController : ApiController
    {
        private IEjemplarService service = new EjemplarService(new LagashContext());

        [Route("{id}/ejemplares")]
        public IEnumerable<Ejemplar> Get(string id)
        {
            return service.Query(o => o.data_id == id);
        }

        [Route("{id}/ejemplares")]
        public IHttpActionResult Post(Ejemplar item)
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
