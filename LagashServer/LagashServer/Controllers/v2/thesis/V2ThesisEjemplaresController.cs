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
    [Authorize]
    [RoutePrefix("v2/thesis")]
    public class V2ThesisEjemplaresController : ApiController
    {
        private IThesisEjemplarService service = new ThesisEjemplarService(new LagashContext());

        [Route("{id}/ejemplares")]
        public IEnumerable<ThesisEjemplar> Get(string id)
        {
            return service.get_asc(o => o.material_id == id, o => o.order);
        }

        [Route("{id}/ejemplares")]
        public IHttpActionResult Post(ThesisEjemplar item)
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
    }
}
