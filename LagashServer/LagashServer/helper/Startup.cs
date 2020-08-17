using Microsoft.Owin;
using Owin;
using System.Data.Entity;
using System.Web.Http;

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
        }
    }
}