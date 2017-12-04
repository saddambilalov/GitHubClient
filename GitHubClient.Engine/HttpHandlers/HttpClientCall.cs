using System.Net.Http;
using System.Threading.Tasks;
using GitHubClient.Engine.Injectors;

namespace GitHubClient.Engine.HttpHandlers
{
    public class HttpClientCall
    {
        private readonly IHttpHeaderInjector _httpHeaderInjector;

        public HttpClientCall(IHttpHeaderInjector httpHeaderInjector)
        {
            this._httpHeaderInjector = httpHeaderInjector;
        }

        public async Task<string> GetStringAsync(string url)
        {
            string result;

            using (var requestHandler = new WebRequestHandler())
            {
                _httpHeaderInjector.InjectHandler(requestHandler);

                using (var httpClient = new HttpClient(requestHandler))
                {
                    _httpHeaderInjector.InjectHeader(httpClient);
                    result = await httpClient.GetStringAsync(url);
                }
            }

            return result;
        }
    }
}
