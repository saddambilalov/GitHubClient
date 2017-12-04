using System.Net.Http;

namespace GitHubClient.Engine.Injectors
{
    internal class GitHubHttpHeaderInjector : IHttpHeaderInjector
    {
        private const string GitHubApiVersion = "v3";
        private static string GitHubApiVersionHeader => $"application/vnd.github{GitHubApiVersion}+json";

        public void InjectHeader(HttpClient httpClient)
        {
            var project = System.Reflection.Assembly.GetCallingAssembly().GetName();
            var projectName = project.Name;
            var projectVersion = project.Version.Major;

            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(GitHubApiVersionHeader));
            httpClient.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue(projectName, projectVersion.ToString()));
        }

        public void InjectHandler(WebRequestHandler requestHandler)
        {
            requestHandler.UseProxy = true;
        }
    }
}
