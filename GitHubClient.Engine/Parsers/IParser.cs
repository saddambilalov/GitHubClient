using System.Collections.Generic;
using GitHubClient.Infracture.Models;

namespace GitHubClient.Engine.Parsers
{
    public interface IParser
    {
        UserInfo ParseUserInfo(string json);
        List<RepositoryInfo> ParseRepositories(string json);
    }
}