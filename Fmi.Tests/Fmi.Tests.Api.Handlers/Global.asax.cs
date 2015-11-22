using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Core;
using Autofac.Integration.WebApi;
using AutoMapper;
using FluentValidation.WebApi;
using Fmi.Tests.Api.Handlers.Filters;
using Fmi.Tests.Contracts.Dto;
using Fmi.Tests.Core.Handlers;
using Fmi.Tests.Core.Handlers.CrossCutting;
using Fmi.Tests.Core.Handlers.Interfaces;
using Fmi.Tests.Core.Sql;
using Fmi.Tests.Core.Sql.Entities;

namespace Fmi.Tests.Api.Handlers
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var config = GlobalConfiguration.Configuration;

            config.MapHttpAttributeRoutes();
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            config.Filters.Add(new BadRequestExceptionAttribute());
            config.Filters.Add(new NotFoundExceptionAttribute());
            config.Filters.Add(new AuthAttribute());
            config.Filters.Add(new ValidationFilterAttribute());

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterFilters(config);

            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);

            RegisterHandlers(builder);
            RegisterContext(builder);

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            FluentValidationModelValidatorProvider.Configure(config);

            config.EnsureInitialized();

            TestsContext.SetInitializer();
            ConfigureMappings();
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

        private static void RegisterContext(ContainerBuilder builder)
        {
            builder.RegisterType<TestsContext>()
                .InstancePerRequest()
                .AsSelf()
                .As<DbContext>();
        }

        private static void ConfigureMappings()
        {
            Mapper.CreateMap<TestDto, TestEntity>().ForAllMembers(opt => opt.Condition(e => !e.IsSourceValueNull));
            Mapper.CreateMap<TestEntity, TestDto>().ForAllMembers(opt => opt.Condition(e => !e.IsSourceValueNull));

            Mapper.CreateMap<QuestionDto, QuestionEntity>().ForAllMembers(opt => opt.Condition(e => !e.IsSourceValueNull));
            Mapper.CreateMap<QuestionEntity, QuestionDto>().ForAllMembers(opt => opt.Condition(e => !e.IsSourceValueNull));

            Mapper.CreateMap<AnswerDto, AnswerEntity>().ForAllMembers(opt => opt.Condition(e => !e.IsSourceValueNull));
            Mapper.CreateMap<AnswerEntity, AnswerDto>().ForAllMembers(opt => opt.Condition(e => !e.IsSourceValueNull));
        }
    }
}