using System;

namespace GitHubClient.Engine.Erros
{
    public class ApiException : Exception, IApiException
    {
		public ApiException(string message)
			: base(message) { }
	}
}