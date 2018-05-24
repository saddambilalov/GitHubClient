using System.Threading.Tasks;
using GitHubClient.Infracture.Models;

namespace GitHubClient.Engine.Agents
{
    public interface IAgent
    {
        Task<UserApiResult> ExecuteTask(string userName);
    }
}