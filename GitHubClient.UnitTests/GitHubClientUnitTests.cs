using System.Threading.Tasks;
using GitHubClient.Engine;
using GitHubClient.Engine.Agents;
using GitHubClient.Engine.Filters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GitHubClient.UnitTests
{
    [TestClass]
    public class GitHubClientUnitTests
    {
        [TestMethod]
        public async Task GetUserInfoWithRepositoriesAsync_CorrectUser()
        {
            var userApiResult = await new GitHubAgent(AppSettings.BaseUrl).GetUserInfoWithRepositoriesAsync("saddambilalov");

            Assert.IsNotNull(userApiResult);
            Assert.IsNotNull(userApiResult.UserInfo);
            Assert.AreEqual(userApiResult.UserInfo.Name, "Saddam Bilalov");
        }

        [TestMethod]
        public async Task GetUserInfoWithRepositoriesAsync_Top5_Repositories_With_Stargazers_Count()
        {
            var userApiResult = await new GitHubAgent(AppSettings.BaseUrl).GetUserInfoWithRepositoriesAsync("saddambilalov");
            Assert.IsNotNull(userApiResult);
            Assert.IsNotNull(userApiResult.Repositories);

            var userApiResultFiltered = RepositoryFilters.FilterRepositoriesByStargazersCount(userApiResult, 5);
            Assert.IsFalse(userApiResultFiltered.Repositories.Count > 5, "The count of repositories could not be greater than 5");
        }
    }
}
