using System.Collections.Generic;
using System.Web.Http;
using LagashServer.helper;
using Wolf.Lagash.Entities.helper.faculties;
using Wolf.Lagash.Services.helpers.faculties;
using Wolf.Lagash.Interfaces.helpers.faculties;

namespace LagashServer.Controllers.v4
{
    [RoutePrefix("v4/carrers")]
    public class V4CareerController : ApiController
    {
        private ICarrerService service = new CarrerService(new LagashContext());

        [Route("")]
        public IEnumerable<Carrer> Get()
        {
            return service.GetAll();
        }
    }
}