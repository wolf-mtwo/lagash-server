using System;
using System.Collections.Generic;
using System.Web.Http;
using LagashServer.helper;
using Wolf.Lagash.Entities.magazine;
using Wolf.Lagash.Services.magazine;
using Wolf.Lagash.Interfaces.magazine;

namespace LagashServer.Controllers.v2.magazines
{
    [Authorize]
    [RoutePrefix("v2/magazines")]
    public class V2MagazineEjemplaresController : ApiController
    {
        private IMagazineEjemplarService service = new MagazineEjemplarService(new LagashContext());

        [Route("{id}/ejemplares")]
        public IEnumerable<MagazineEjemplar> Get(string id)
        {
            return service.get_asc(o => o.material_id == id, o => o.order);
        }

        [Route("{id}/ejemplares")]
        public IHttpActionResult Post(MagazineEjemplar item)
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