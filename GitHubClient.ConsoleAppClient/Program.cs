using GitHubClient.Engine;
using GitHubClient.Engine.Agents;
using GitHubClient.Engine.Erros;
using GitHubClient.Engine.Filters;
using System;
using GitHubClient.Engine.ApiMethodsUrl;
using GitHubClient.Engine.Parsers;

namespace GitHubClient.ConsoleAppClient
{
	internal class Program
	{
		private static void Main()
		{
			while (true)
			{
				Console.Write("Please enter a GitHub user name : ");
				var username = Console.ReadLine();

				try
				{
					var userInfoWithRepositories = new GitHubAgent(new GitHubApiMethods(AppSettings.BaseUrl), new JsonParser())
						.ExecuteTask(username).GetAwaiter().GetResult();

					var userApiResultFiltered =
						RepositoryFilters.FilterRepositoriesByStargazersCount(userInfoWithRepositories, 5);

					new DisplayData(userApiResultFiltered).DisplayOnScreen();
				}
				catch (ApiException ex)
				{
					Console.WriteLine();
					Console.WriteLine($"Error: {ex.Message}");
					Console.WriteLine();
				}
			}
		}
	}
}