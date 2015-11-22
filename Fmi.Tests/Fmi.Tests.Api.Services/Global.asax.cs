using System.Data.Entity;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using FluentValidation.WebApi;
using Fmi.Tests.Api.Services.Filters;
using Fmi.Tests.Contracts.Dto;
using Fmi.Tests.Core.Services.Interfaces;
using Fmi.Tests.Core.Services.Services;
using Fmi.Tests.Core.Sql;
using Fmi.Tests.Core.Sql.Entities;

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
            config.Filters.Add(new NotFoundExceptionAttribute());
            config.Filters.Add(new AuthAttribute());
            config.Filters.Add(new ValidationFilterAttribute());

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterFilters(config);

            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);

            RegisterServices(builder);
            RegisterContext(builder);

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            FluentValidationModelValidatorProvider.Configure(config);

            config.EnsureInitialized();

            TestsContext.SetInitializer();
            ConfigureMappings();
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