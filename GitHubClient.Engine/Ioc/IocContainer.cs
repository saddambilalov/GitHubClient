using System.Web;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using GitHubClient.Engine.Agents;
using GitHubClient.Engine.ApiMethodsUrl;
using GitHubClient.Engine.Erros;
using GitHubClient.Engine.HttpHandlers;
using GitHubClient.Engine.Injectors;
using GitHubClient.Engine.Parsers;

namespace GitHubClient.Engine.Ioc
{
    public static class IocContainer
    {
        public static WindsorContainer GetContainer()
        {
            var container = new WindsorContainer();
            container.Register(Component.For<IAgent>().ImplementedBy<GitHubAgent>());
            container.Register(Component.For<IApiException>().ImplementedBy<ApiException>());
            container.Register(Component.For<IHttpClientCall>().ImplementedBy<HttpClientCall>());
            container.Register(Component.For<IHttpHandler>().ImplementedBy<HttpApplication>());
            container.Register(Component.For<IHttpHeaderInjector>().ImplementedBy<GitHubHttpHeaderInjector>());
            container.Register(Component.For<IParser>().ImplementedBy<JsonParser>());
            container.Register(Component.For<IApiMethods>().ImplementedBy<GitHubApiMethods>());

            return container;
        }
    }
}
