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
using Wolf.Lagash.Interfaces;
using LagashServer.helper;
using Wolf.Lagash.Entities.books;
using Wolf.Lagash.Interfaces.helper.ejemplar;
using Wolf.Lagash.Entities.helper.ejemplar;
using Wolf.Lagash.Services.helper.ejemplar;
using LagashServer.Controllers.helpers;

namespace LagashServer.Controllers.v1.helper.ejemplar
{
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