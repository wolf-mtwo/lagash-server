using LagashServer.helper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace LagashServer
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // remove this code line for production environment
            Database.SetInitializer<LagashContext>(null);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
