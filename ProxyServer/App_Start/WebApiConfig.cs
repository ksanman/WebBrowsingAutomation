using ProxyServer.Handlers;
using System.Net.Http;
using System.Web.Http;

namespace ProxyServer
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
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
        }
    }
}
