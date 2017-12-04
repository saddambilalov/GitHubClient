using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitHubClient.Engine.ApiMethodsUrl;
using GitHubClient.Engine.HttpHandlers;
using GitHubClient.Engine.Injectors;
using GitHubClient.Infracture.Models;
using Newtonsoft.Json;

namespace GitHubClient.Engine.Agents
{
    public class GitHubAgent
    {
        private readonly string _baseUrl;

        public GitHubAgent(string baseUrl)
        {
            this._baseUrl = baseUrl;
        }

        public async Task<UserApiResult> GetUserInfoWithRepositoriesAsync(string userName)
        {
            var userInfo = await GetUserInfo(new GitHubApiMethods(_baseUrl).GetUserInfoUrl(userName));
            var repositories = await GetRepositoryInfo(userInfo.ReposUrl);

            return new UserApiResult
            {
                UserInfo = userInfo,
                Repositories = repositories
            };
        }

        private static async Task<UserInfo> GetUserInfo(string url)
        {
            var jsonForUserInfo = await new HttpClientCall(new GitHubHttpHeaderInjector()).GetStringAsync(url);
            var userInfo = JsonConvert.DeserializeObject<UserInfo>(jsonForUserInfo);

            return userInfo;
        }

        private static async Task<List<RepositoryInfo>> GetRepositoryInfo(string url)
        {
            var jsonForRepositories = await new HttpClientCall(new GitHubHttpHeaderInjector()).GetStringAsync(url);
            var repositories = JsonConvert.DeserializeObject<List<RepositoryInfo>>(jsonForRepositories);

            return repositories;
        }
        
    }
}
