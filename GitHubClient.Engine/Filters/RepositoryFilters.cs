﻿using GitHubClient.Infracture.Models;
using System.Linq;

namespace GitHubClient.Engine.Filters
{
	public static class RepositoryFilters
	{
		public static UserApiResult FilterRepositoriesByStargazersCount(UserApiResult userApiResult, int stargazersCount)
		{
			var result = userApiResult
				.Repositories
				.OrderByDescending(obj => obj.StargazersCount)
				.Take(stargazersCount)
				.ToList();

			userApiResult.Repositories = result;

			return userApiResult;
		}
	}
}