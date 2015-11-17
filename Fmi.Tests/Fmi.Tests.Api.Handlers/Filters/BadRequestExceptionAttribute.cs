using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using Fmi.Tests.Core.Handlers.Exceptions;

namespace Fmi.Tests.Api.Handlers.Filters
{
    public class BadRequestExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is BadRequestException)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.BadRequest, new HttpError(actionExecutedContext.Exception.Message));
            }
        }
    }
}