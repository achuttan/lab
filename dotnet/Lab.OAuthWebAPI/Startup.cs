using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Lab.OAuth.API.Startup))]

namespace Lab.OAuth.API
{
    public class Startup
    {
        /// <summary>
        /// IAppBuilder is supplied by runtime and is an interface to set up our application with Owin server.
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            // HttpConfiguration is used to configure Routes. We pass this to the WebApiConfig.
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);

            // wire up ASP.NET Web API to our Owin server pipeline.
            app.UseWebApi(config);

        }
    }
}
