using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

//[assembly: OwinStartup(typeof(LagashServer.helper.Startup))]
namespace LagashServer.helper
{
    public class Startup
    {
        //public void Configuration(IAppBuilder app)
        //{
        //    HttpConfiguration config = new HttpConfiguration();
        //    WebApiConfig.Register(config);
        //    app.UseWebApi(config);
        //}

    }

    //public partial class Startup
    //{

    //    //public void ConfigureOAuth(IAppBuilder app)
    //    //{
    //    //    OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
    //    //    {
    //    //        AllowInsecureHttp = true,
    //    //        TokenEndpointPath = new PathString("/token"),
    //    //        AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),  //<---- Right here
    //    //        Provider = new SimpleAuthorizationServerProvider()
    //    //    };

    //    //    // Token Generation
    //    //    app.UseOAuthAuthorizationServer(OAuthServerOptions);
    //    //    app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

    //    //}

    //    //public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

    //    //public static string PublicClientId { get; private set; }

    //    //// For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
    //    //public void ConfigureAuth(IAppBuilder app)
    //    //{
    //    //    // Configure the db context and user manager to use a single instance per request
    //    //    app.CreatePerOwinContext(LagashContext.Create);
    //    //    app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

    //    //    // Enable the application to use a cookie to store information for the signed in user
    //    //    // and to use a cookie to temporarily store information about a user logging in with a third party login provider
    //    //    app.UseCookieAuthentication(new CookieAuthenticationOptions());
    //    //    app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

    //    //    // Configure the application for OAuth based flow
    //    //    PublicClientId = "self";
    //    //    OAuthOptions = new OAuthAuthorizationServerOptions
    //    //    {
    //    //        TokenEndpointPath = new PathString("/Token"),
    //    //        Provider = new ApplicationOAuthProvider(PublicClientId),
    //    //        AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
    //    //        AccessTokenExpireTimeSpan = TimeSpan.FromDays(14)
    //    //        //AllowInsecureHttp = true
    //    //    };

    //    //    // Enable the application to use bearer tokens to authenticate users
    //    //    app.UseOAuthBearerTokens(OAuthOptions);

    //    //    // Uncomment the following lines to enable logging in with third party login providers
    //    //    //app.UseMicrosoftAccountAuthentication(
    //    //    //    clientId: "",
    //    //    //    clientSecret: "");

    //    //    //app.UseTwitterAuthentication(
    //    //    //    consumerKey: "",
    //    //    //    consumerSecret: "");

    //    //    //app.UseFacebookAuthentication(
    //    //    //    appId: "",
    //    //    //    appSecret: "");

    //    //    //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
    //    //    //{
    //    //    //    ClientId = "",
    //    //    //    ClientSecret = ""
    //    //    //});
    //    //}
    //}
    /*
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }

    public void ConfigureAuth(IAppBuilder app)
    {
        app.CreatePerOwinContext(ApplicationDbContext.Create);
        app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
        app.UseCookieAuthentication(new CookieAuthenticationOptions());
        app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

        // Configure the application for OAuth based flow
        PublicClientId = "self";
        OAuthOptions = new OAuthAuthorizationServerOptions
        {
            TokenEndpointPath = new PathString("/Token"),
            Provider = new ApplicationOAuthProvider(PublicClientId),
            AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
            AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
            // In production mode set AllowInsecureHttp = false
            AllowInsecureHttp = true
        };
        app.UseOAuthBearerTokens(OAuthOptions); 

}*/
}