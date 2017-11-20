using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace mattberther.chef
{
    public class ChefServer
    {
        private readonly Uri server;

        public ChefServer(string server)
            : this(new Uri(server))
        {
        }

        public ChefServer(Uri server)
        {
            this.server = server;
        }

        public HttpResponseMessage SendRequest(AuthenticatedRequest request)
        {
            return SendRequestAsync(request).Result;
        }

        public async Task<HttpResponseMessage> SendRequestAsync(AuthenticatedRequest request)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = server;

                var message = request.Create();
                var result = await client.SendAsync(message);

                result.EnsureSuccessStatusCode();

                return result;
            }
        }
    }
}
