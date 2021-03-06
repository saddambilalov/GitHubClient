﻿using GitHubClient.Engine.ApiMethodsUrl;
using GitHubClient.Engine.Erros;
using GitHubClient.Engine.HttpHandlers;
using GitHubClient.Engine.Parsers;
using GitHubClient.Infracture.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitHubClient.Engine.Agents
{
    public class GitHubAgent : IAgent
    {
	    private readonly IParser _parser;
        private readonly IApiMethods _gitHubApiMethods;
        private readonly IHttpClientCall _httpClientCall;
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		public GitHubAgent(IApiMethods gitHubApiMethods, IParser parser, IHttpClientCall httpClientCall)
		{
		    _gitHubApiMethods = gitHubApiMethods;
            _parser = parser;
		    _httpClientCall = httpClientCall;
		}

		public async Task<UserApiResult> ExecuteTask(string userName)
		{
			try
			{
				var userInfo = await GetUserInfo(_gitHubApiMethods.GetUserInfoUrl(userName));
				var repositories = await GetRepositoryInfo(userInfo.ReposUrl);

				return new UserApiResult
				{
					UserInfo = userInfo,
					Repositories = repositories
				};
			}
			catch (ApiException ex)
			{
				throw;
			}
			catch (Exception ex)
			{
				Log.Error(ex);
				throw new ApiException("Unexpected error has occurred. You can find details in the backendLogFile.log file.");
			}
		}

		private async Task<UserInfo> GetUserInfo(string url)
		{
			var jsonForUserInfo = await _httpClientCall.GetStringAsync(url);
			var userInfo = _parser.ParseUserInfo(jsonForUserInfo);

			return userInfo;
		}

		private async Task<List<RepositoryInfo>> GetRepositoryInfo(string url)
		{
			var jsonForRepositories = await _httpClientCall.GetStringAsync(url);
			var repositories = _parser.ParseRepositories(jsonForRepositories);

			return repositories;
		}
	}
}