using System;

namespace GitHubClient.Engine.Erros
{
    public class ApiException : Exception
    {
        public ApiException(string message)
            : base(message) { }
    }
}
