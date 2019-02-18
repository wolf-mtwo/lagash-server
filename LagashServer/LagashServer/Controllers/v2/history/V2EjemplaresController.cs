using LagashServer.helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Wolf.Lagash.Entities;
using Wolf.Lagash.Entities.helper.ejemplar;
using Wolf.Lagash.Interfaces;
using Wolf.Lagash.Interfaces.helper.ejemplar;
using Wolf.Lagash.Services;
using Wolf.Lagash.Services.helper.ejemplar;

namespace LagashServer.Controllers.v2.history
{
    [RoutePrefix("v2/resource")]
    public class V2EjemplaresController : ApiController
    {
        private IEjemplarService service = new EjemplarService(new LagashContext());

        [Route("{id}/ejemplares")]
        public IEnumerable<Ejemplar> Get(string id)
        {
            return service.Query(o => o.material_id == id);
        }

        [Route("{id}/ejemplares")]
        public IHttpActionResult Post(Ejemplar item)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            try {
                //Ejemplar ejemplar = service.FindOne(o => o.code == item.code);
                //if (ejemplar != null) {
                //    return new LagashActionResult("La signatura topográfica ya existe");
                //}
                //service.Create(item);
                service.Commit();
            } catch (Exception e) {
                return new LagashActionResult(e.Message);
            }
            return Ok(item);
        }
    }
}
