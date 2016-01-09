using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Carvana.B.Gateway.Startup;
using Nancy.Hosting.Self;

namespace Carvana.B.Gateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var uri = new Uri("http://localhost:5678");
            var bootstrapper = new Bootstrapper();
            var hostConfig = new HostConfiguration { UrlReservations = new UrlReservations { CreateAutomatically = true } };
            using (NancyHost host = new NancyHost(bootstrapper, hostConfig, uri))
            {
                host.Start();
                Console.Out.Write("Host Started on " + uri.AbsolutePath);

                Thread.Sleep(Timeout.Infinite);
            }
        }
    }
}
