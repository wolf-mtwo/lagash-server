﻿using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

[assembly: OwinStartup(typeof(LagashServer.helper.Startup))]
namespace LagashServer.helper
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Database.SetInitializer<LagashContext>(new DropCreateDatabaseIfModelChanges<LagashContext>());

            HttpConfiguration config = new HttpConfiguration();
            
            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);

            /*Database.SetInitializer<LagashContext>(new RecreateDatabaseIfModelChanges<LagashContext>());
            Database.SetInitializer<LagashContext>(new RecreateDatabaseIfModelChanges<LagashContext>());
            Database.SetInitializer<LagashContext>(new DropCreateDatabaseIfModelChanges<LagashContext>());*/
            
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}