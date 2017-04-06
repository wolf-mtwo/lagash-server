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
    [RoutePrefix("p1/login")]
    public class LoginController : ApiController
    {
        private IUsersService service = new UsersService(new LagashContext());

        [Route("")]
        [ResponseType(typeof(User))]
        public IHttpActionResult Post(Login login)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            User user = service.login(login.email, login.password);
            if (user != null) {
                var payload = new Dictionary<string, object>() {
                    {"_id", user._id},
                    {"email", user.email}
                };
                var secretKey = "lagash-server";
                user.token = new Token() {
                    session_id = JWT.JsonWebToken.Encode(payload, secretKey, JWT.JwtHashAlgorithm.HS256)
                };
                return Ok(user);
            } else {
                return new LagashActionResult("Invalid user account");
            }
        }
    }
}
