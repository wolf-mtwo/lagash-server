using System.Collections.Generic;
using System.Web.Http;
using Wolf.Lagash.Entities;
using LagashServer.helper;
using Wolf.Lagash.Entities.helper.faculties;
using Wolf.Lagash.Services.helpers.faculties;
using Wolf.Lagash.Interfaces.helpers.faculties;

namespace LagashServer.Controllers.v4
{
    [RoutePrefix("v4/faculties")]
    public class V4FacultyController : ApiController
    {
        private IFacultyService service = new FacultyService(new LagashContext());

        [Route("")]
        public IEnumerable<Faculty> Get()
        {
            return service.GetAll();
        }
    }
}