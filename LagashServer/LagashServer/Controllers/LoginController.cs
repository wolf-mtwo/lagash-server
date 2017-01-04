using LagashServer.helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Wargos.Lagash.Entities;
using Wargos.Lagash.Interfaces;
using Wargos.Lagash.Services;

namespace LagashServer.Controllers
{
    public class LoginController : ApiController
    {
        private IUserService service = new UserService(new LagashContext());

        public IQueryable<User> PostLogin(string username, string password)
        {
            try
            {
                service.login(username, password);
            }
            catch (Exception)
            {
                throw;
            }
            
            //return service.GetAll1();
            return null;
        }
    }
}
