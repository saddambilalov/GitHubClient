namespace GitHubClient.Engine.ApiMethodsUrl
{
	public class GitHubApiMethods
	{
		private readonly string _baseUrl;

	    public GitHubApiMethods(string baseUrl)
		{
			this._baseUrl = baseUrl;
		}

		public string GetUserInfoUrl(string userName)
		{
			return $"{_baseUrl}/users/{userName}";
		}
	}
}