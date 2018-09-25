using System;
using System.Net.Http;

namespace ProxyServer.Handlers
{
    public class ProxyHandler : DelegatingHandler
    {
        protected override async System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            if (request.Method == HttpMethod.Get || request.Method == HttpMethod.Trace)
            {
                request.Content = null;
            }

            UriBuilder forwardUri = new UriBuilder(request.RequestUri)
            {
                //strip off the proxy port and replace with an Http port
                Port = 80
            };

            //send it on to the requested URL
            request.RequestUri = forwardUri.Uri;

            using (var client = new HttpClient())
            {
                var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                return response;
            }
        }
    }
}