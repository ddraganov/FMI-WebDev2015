using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using Fmi.Tests.Core.Handlers.Exceptions;

namespace Fmi.Tests.Api.Handlers.Filters
{
    public class NotFoundExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is NotFoundException)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.NotFound, new HttpError(actionExecutedContext.Exception.Message));
            }
        }
    }
}