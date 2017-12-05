using System.Net.Http;

namespace GitHubClient.Engine.Injectors
{
	public interface IHttpHeaderInjector
	{
		void InjectHeader(HttpClient httpClient);

		void InjectHandler(WebRequestHandler requestHandler);
	}
}