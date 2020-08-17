using LagashServer.helper;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Configuration;
using System.Security.Claims;
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
            if (login == null)
                return BadRequest(ModelState);
            login.password = new EncryptPassword().EncodePassword(login.password);
            User user = service.login(login.email, login.password);
            if (user != null)
            {
                user.token = new Token {session_id = GenerateTokenJwt(user.email, user._id) };
                return Ok(user);
            }
            else
            {
                return new LagashActionResult("Invalid user account");
            }
        }

        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }

        #region Validation
        public static string GenerateTokenJwt(string email, string id)
        {
            var secretKey = ConfigurationManager.AppSettings["JWT_SECRET_KEY"];
            var audienceToken = ConfigurationManager.AppSettings["JWT_AUDIENCE_TOKEN"];
            var issuerToken = ConfigurationManager.AppSettings["JWT_ISSUER_TOKEN"];
            var expireTime = ConfigurationManager.AppSettings["JWT_EXPIRE_MINUTES"];

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] { 
                new Claim(ClaimTypes.Email, email),
                new Claim("_id", id)
            });

            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: audienceToken,
                issuer: issuerToken,
                subject: claimsIdentity,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime)),
                signingCredentials: signingCredentials);

            var token = tokenHandler.WriteToken(jwtSecurityToken);
            return token;
        }
        #endregion
    }
}
