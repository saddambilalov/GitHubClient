using System;
using System.Collections.Generic;
using GitHubClient.Engine.Erros;
using GitHubClient.Infracture.Models;
using Newtonsoft.Json;

namespace GitHubClient.Engine.Parsers
{
    internal static class JsonParser
    {
        internal static UserInfo ParseUserInfo(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<UserInfo>(json);
            }
            catch (Exception)
            {
                throw new ApiException("Could not parse user Info");
            }
        }

        internal static List<RepositoryInfo> ParseRepositories(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<RepositoryInfo>>(json);
            }
            catch (Exception)
            {
                throw new ApiException("Could not parse repository Info");
            }

        }
    }
}
