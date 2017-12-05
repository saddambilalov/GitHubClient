using Newtonsoft.Json;

namespace GitHubClient.Infracture.Models
{
	public class RepositoryInfo
	{
		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "stargazers_count")]
		public int StargazersCount { get; set; }
	}
}