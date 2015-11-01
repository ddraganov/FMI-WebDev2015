using System.Linq;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Core;
using Autofac.Integration.WebApi;
using Fmi.Tests.Core.Handlers;
using Fmi.Tests.Core.Handlers.CrossCutting;
using Fmi.Tests.Core.Handlers.Interfaces;
using Fmi.Tests.Core.Services.Interfaces;
using Fmi.Tests.Core.Services.Services;

namespace Fmi.Tests.Api.Handlers
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var config = GlobalConfiguration.Configuration;

            config.MapHttpAttributeRoutes();
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterFilters(config);

            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);

            RegisterHandlers(builder);
            RegisterServices(builder);

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            config.EnsureInitialized();
        }

        private static void RegisterHandlers(ContainerBuilder builder)
        {
            builder.RegisterType<Mediator>()
                .As<IMediator>();

            builder.RegisterAssemblyTypes(typeof(Mediator).Assembly)
                .As(type => type.GetInterfaces()
                    .Where(interfaceType => interfaceType.IsClosedTypeOf(typeof(IRequestHandler<,>)))
                    .Select(interfaceType => new KeyedService("handler", interfaceType)));

            builder.RegisterGenericDecorator(
                typeof(LoggingHandlerDecorator<,>),
                typeof(IRequestHandler<,>),
                fromKey: "handler");
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<QuestionsService>()
                .As<IQuestionsService>()
                .InstancePerRequest();

            builder.RegisterType<TestsService>()
                .As<ITestsService>()
                .InstancePerRequest();
        }
    }
}