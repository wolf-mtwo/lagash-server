using System.Collections.Generic;
using System.Web.Http;
using Wolf.Lagash.Services;
using Wolf.Lagash.Entities;
using Wolf.Lagash.Interfaces;
using LagashServer.helper;

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