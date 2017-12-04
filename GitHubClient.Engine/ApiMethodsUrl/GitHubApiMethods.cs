namespace GitHubClient.Engine.ApiMethodsUrl
{
    internal class GitHubApiMethods
    {
        private readonly string _baseUrl;

        internal GitHubApiMethods(string baseUrl)
        {
            this._baseUrl = baseUrl;
        }

        public string GetUserInfoUrl(string userName)
        {
            return $"{_baseUrl}/users/{userName}";
        }
    }
}
