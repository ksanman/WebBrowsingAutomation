using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace Server
{
    public class ProxyServer
    {
        public ProxyServer()
        {
            HttpSelfHostConfiguration config = GetServerConfiguration();

            using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                Console.WriteLine("Press Enter to quit.");
                Console.ReadLine();
            }

        }

        private static HttpSelfHostConfiguration GetServerConfiguration()
        {
            var config = new HttpSelfHostConfiguration("http://localhost:12434");

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Proxy",
                routeTemplate: "{*path}",
               handler: HttpClientFactory.CreatePipeline(
                   innerHandler: new HttpClientHandler(),
                   handlers: new DelegatingHandler[] { new ProxyHandler() }),
                defaults: new { path = RouteParameter.Optional },
                constraints: null
            );
            return config;
        }
    }
}
