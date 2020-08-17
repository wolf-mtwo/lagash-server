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
using Wolf.Lagash.Services;
using Wolf.Lagash.Entities;
using LagashServer.helper;
using Wolf.Lagash.Entities.books;
using Wolf.Lagash.Interfaces.helper.ejemplar;
using Wolf.Lagash.Entities.helper.ejemplar;
using Wolf.Lagash.Services.helper.ejemplar;
using LagashServer.Controllers.helpers;
using Wolf.Lagash.Entities.magazine;
using Wolf.Lagash.Services.magazine;
using Wolf.Lagash.Interfaces.magazine;

namespace LagashServer.Controllers.v1.helper.ejemplar
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