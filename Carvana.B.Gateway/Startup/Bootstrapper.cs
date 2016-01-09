using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Hosting.Self;
using Nancy.TinyIoc;

namespace Carvana.B.Gateway.Startup
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        private TinyIoCContainer _container;
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            _container = container;

            var configuration = new HostConfiguration() { UrlReservations = { CreateAutomatically = true } };
            container.Register(configuration);

            pipelines.AfterRequest += (ctx) =>
            {
                ctx.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                ctx.Response.Headers.Add("Access-Control-Allow-Methods", "POST,GET,PUT,DELETE,OPTIONS");
                ctx.Response.Headers.Add("Access-Control-Allow-Headers", "Accept, Origin, Content-type,Authorization");
            };

            base.ApplicationStartup(container, pipelines);
        }
    }
}
