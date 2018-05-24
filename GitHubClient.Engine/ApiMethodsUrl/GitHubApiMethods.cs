namespace GitHubClient.Engine.ApiMethodsUrl
{
    public class GitHubApiMethods : IApiMethods
    {
        public string GetBaseUrl => "https://api.github.com";

        public string GetUserInfoUrl(string userName)
        {
            return $"{GetBaseUrl}/users/{userName}";
        }
    }
}