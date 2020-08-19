using LagashServer.Controllers.helpers;
using System.Web.Http;

namespace LagashServer.Controllers
{
    public class HomeController : ApiController
    {
        [Route("")]
        public Information Get()
        {
            return new Information("0.0.0");
        }
    }
}