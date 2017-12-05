using GitHubClient.Engine.ApiMethodsUrl;
using GitHubClient.Engine.Erros;
using GitHubClient.Engine.HttpHandlers;
using GitHubClient.Engine.Injectors;
using GitHubClient.Engine.Parsers;
using GitHubClient.Infracture.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitHubClient.Engine.Agents
{
	public class GitHubAgent
	{
		private readonly string _baseUrl;
		private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		public GitHubAgent(string baseUrl)
		{
			this._baseUrl = baseUrl;
		}

		public async Task<UserApiResult> GetUserInfoWithRepositoriesAsync(string userName)
		{
			try
			{
				var userInfo = await GetUserInfo(new GitHubApiMethods(_baseUrl).GetUserInfoUrl(userName));
				var repositories = await GetRepositoryInfo(userInfo.ReposUrl);

				return new UserApiResult
				{
					UserInfo = userInfo,
					Repositories = repositories
				};
			}
			catch (ApiException)
			{
				throw;
			}
			catch (Exception ex)
			{
				Log.Error(ex);
				throw new ApiException("Unexpected error has occurred. You can find details in the backendLogFile.log file.");
			}
		}

		private static async Task<UserInfo> GetUserInfo(string url)
		{
			var jsonForUserInfo = await new HttpClientCall(new GitHubHttpHeaderInjector()).GetStringAsync(url);
			var userInfo = JsonParser.ParseUserInfo(jsonForUserInfo);

			return userInfo;
		}

		private static async Task<List<RepositoryInfo>> GetRepositoryInfo(string url)
		{
			var jsonForRepositories = await new HttpClientCall(new GitHubHttpHeaderInjector()).GetStringAsync(url);
			var repositories = JsonParser.ParseRepositories(jsonForRepositories);

			return repositories;
		}
	}
}