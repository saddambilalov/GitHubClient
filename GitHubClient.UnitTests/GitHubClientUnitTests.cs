using GitHubClient.Engine;
using GitHubClient.Engine.Agents;
using GitHubClient.Engine.Filters;
using System.Threading.Tasks;
using GitHubClient.Engine.Parsers;
using NUnit.Framework;

namespace GitHubClient.UnitTests
{
    public class GitHubClientUnitTests
    {
        private GitHubAgent _gitHubAgent;

        [SetUp]
        public void SetUp()
        {
            _gitHubAgent = new GitHubAgent(AppSettings.BaseUrl, new JsonParser());
        }

        [TearDown]
        public void TearDown()
        {
            _gitHubAgent = null;
        }

        [TestCase("saddambilalov", "Saddam Bilalov")]
        [TestCase("thedevsaddam", "Saddam H")]
        public async Task GetUserInfoWithRepositoriesAsync_CorrectUser(string input, string expectedOutput)
        {
            var userApiResult = await _gitHubAgent.GetUserInfoWithRepositoriesAsync(input);

            Assert.IsNotNull(userApiResult.UserInfo);
            Assert.That(userApiResult.UserInfo.Name, Is.EqualTo(expectedOutput));
        }

        [Test]
        public async Task GetUserInfoWithRepositoriesAsync_Top5_Repositories_With_Stargazers_Count()
        {
            var userApiResult = await _gitHubAgent.GetUserInfoWithRepositoriesAsync("saddambilalov");
            Assert.That(userApiResult.Repositories, Is.Not.Null);

            var userApiResultFiltered = RepositoryFilters.FilterRepositoriesByStargazersCount(userApiResult, 5);
            Assert.That(userApiResultFiltered.Repositories.Count > 5, Is.Not.EqualTo("The count of repositories could not be greater than 5"));
        }
    }
}