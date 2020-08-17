using System;
using System.Collections.Generic;
using System.Web.Http;
using LagashServer.helper;
using Wolf.Lagash.Entities.newspaper;
using Wolf.Lagash.Services.newspaper;
using Wolf.Lagash.Interfaces.newspaper;

namespace LagashServer.Controllers.v2.newspaper
{
    [Authorize]
    [RoutePrefix("v2/newspapers")]
    public class V2NewspaperEjemplaresController : ApiController
    {
        private INewspaperEjemplarService service = new NewspaperEjemplarService(new LagashContext());

        [Route("{id}/ejemplares")]
        public IEnumerable<NewspaperEjemplar> Get(string id)
        {
            return service.get_asc(o => o.material_id == id, o => o.order);
        }

        [Route("{id}/ejemplares")]
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
    }
}