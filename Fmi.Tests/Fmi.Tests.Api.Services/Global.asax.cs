using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Fmi.Tests.Api.Services.Filters;
using Fmi.Tests.Core.Services.Interfaces;
using Fmi.Tests.Core.Services.Services;

namespace Fmi.Tests.Api.Services
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var config = GlobalConfiguration.Configuration;

            config.MapHttpAttributeRoutes();
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            config.Filters.Add(new BadRequestExceptionAttribute());
            config.Filters.Add(new AuthActionAttribute());

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterFilters(config);

            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);

            RegisterServices(builder);

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            config.EnsureInitialized();
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