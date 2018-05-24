using System.Threading.Tasks;

namespace GitHubClient.Engine.HttpHandlers
{
    public interface IHttpClientCall
    {
        Task<string> GetStringAsync(string url);
    }
}