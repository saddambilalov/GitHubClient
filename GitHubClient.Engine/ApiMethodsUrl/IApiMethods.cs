namespace GitHubClient.Engine.ApiMethodsUrl
{
    public interface IApiMethods
    {
        string GetBaseUrl { get; }
        string GetUserInfoUrl(string userName);
    }
}