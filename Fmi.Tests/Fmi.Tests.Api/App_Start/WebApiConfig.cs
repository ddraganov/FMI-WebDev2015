using System.Web.Http;

namespace Fmi.Tests.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "HandlersQuestionsApi",
                routeTemplate: "api/handlers/questions/{id}",
                defaults: new
                {
                    id = RouteParameter.Optional,
                    controller = "HandlersQuestions"
                }
            );

            config.Routes.MapHttpRoute(
                name: "HandlersTestsApi",
                routeTemplate: "api/handlers/tests/{id}",
                defaults: new
                {
                    id = RouteParameter.Optional,
                    controller = "HandlersTests"
                }
            );

            config.Routes.MapHttpRoute(
                name: "ServicesQuestionsApi",
                routeTemplate: "api/services/questions/{id}",
                defaults: new
                {
                    id = RouteParameter.Optional,
                    controller = "ServicesQuestions"
                }
            );

            config.Routes.MapHttpRoute(
                name: "ServicesTestsApi",
                routeTemplate: "api/services/tests/{id}",
                defaults: new
                {
                    id = RouteParameter.Optional,
                    controller = "ServicesTests"
                }
            );
        }
    }
}
