using GitHubClient.Engine.Agents;
using GitHubClient.Engine.Filters;
using System.Threading.Tasks;
using GitHubClient.Engine.Ioc;
using NUnit.Framework;

namespace GitHubClient.UnitTests
{
    public class GitHubClientUnitTests
    {
        private IAgent _gitHubAgent;

        [SetUp]
        public void SetUp()
        {
            _gitHubAgent = IocContainer.GetContainer().Resolve<IAgent>();
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
            var userApiResult = await _gitHubAgent.ExecuteTask(input);

            Assert.IsNotNull(userApiResult.UserInfo);
            Assert.That(userApiResult.UserInfo.Name, Is.EqualTo(expectedOutput));
        }

        [Test]
        [TestCase("saddambilalov", 5)]
        public async Task GetUserInfoWithRepositoriesAsync_Top5_Repositories_With_Stargazers_Count(string userName, int count)
        {
            var userApiResult = await _gitHubAgent.ExecuteTask(userName);
            Assert.That(userApiResult.Repositories, Is.Not.Null);

            var userApiResultFiltered = RepositoryFilters.FilterRepositoriesByStargazersCount(userApiResult, 5);
            Assert.That(userApiResultFiltered.Repositories, Has.Count.LessThanOrEqualTo(5));
        }
    }
}