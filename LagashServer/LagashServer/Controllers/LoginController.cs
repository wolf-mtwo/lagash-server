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
    public class LoginController : ApiController
    {
        private IUserService service = new UserService(new LagashContext());

        public IHttpActionResult GetLogin()
        {
            return null;
        }

        // POST: api/login
        [ResponseType(typeof(Session))]
        public IHttpActionResult Post(Login login)
        {   
            User user = service.login(login.email, login.password);
            if (user != null)
            {
                Session session = new Session();
                session.name = user.name;
                var payload = new Dictionary<string, object>()
                {
                    { "claim1", 0 },
                    { "claim2", "claim2-value" }
                };
                var secretKey = "lagash-server";
                session.token = JWT.JsonWebToken.Encode(payload, secretKey, JWT.JwtHashAlgorithm.HS256);
                return Ok(session);
            } else
            {
                // change error status code
                return new InternarServerActionResult("Invalid user account");
            }
        }
    }
}
