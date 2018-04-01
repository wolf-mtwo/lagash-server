using LagashServer.helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Wolf.Lagash.Entities;
using Wolf.Lagash.Interfaces;
using Wolf.Lagash.Services;

namespace LagashServer.Controllers
{
    [RoutePrefix("p1/logout")]
    public class LogoutController : ApiController
    {
        private IUsersService service = new UsersService(new LagashContext());

        [Route("")]
        [ResponseType(typeof(User))]
        public IHttpActionResult Post()
        {
            return Ok();
        }
    }
}
