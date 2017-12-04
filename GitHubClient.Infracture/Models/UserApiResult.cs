using System.Collections.Generic;
using Newtonsoft.Json;

namespace GitHubClient.Infracture.Models
{
    public class UserApiResult
    {
        [JsonProperty(PropertyName = "userInfo")]
        public UserInfo UserInfo { get; set; }

        [JsonProperty(PropertyName = "repositories")]
        public List<RepositoryInfo> Repositories { get; set; }

        [JsonProperty(PropertyName = "errorMessage")]
        public string ErrorMessage { get; set; }


    }
}
