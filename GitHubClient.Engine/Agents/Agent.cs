using System;
using System.Threading.Tasks;
using GitHubClient.Infracture.Models;

namespace GitHubClient.Engine.Agents
{
    public class Agent
    {
        public async Task<UserApiResult> GetUserInfoWithRepositoriesAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public async Task<UserApiResult> FilterRepositoriesByStargazersCount(UserApiResult userApiResult, int stargazersCount)
        {
            throw new NotImplementedException();
        }
    }
}
