using GitHubClient.Engine.Erros;
using GitHubClient.Infracture.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GitHubClient.Engine.Parsers
{
	internal static class JsonParser
	{
		private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		internal static UserInfo ParseUserInfo(string json)
		{
			try
			{
				return JsonConvert.DeserializeObject<UserInfo>(json);
			}
			catch (Exception ex)
			{
				Log.Error(ex);
				throw new ApiException("Could not parse user Info");
			}
		}

		internal static List<RepositoryInfo> ParseRepositories(string json)
		{
			try
			{
				return JsonConvert.DeserializeObject<List<RepositoryInfo>>(json);
			}
			catch (Exception ex)
			{
				Log.Error(ex);
				throw new ApiException("Could not parse repository Info");
			}
		}
	}
}