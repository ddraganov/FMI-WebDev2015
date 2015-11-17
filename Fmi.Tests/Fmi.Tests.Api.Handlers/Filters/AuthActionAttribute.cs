using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Fmi.Tests.Contracts;

namespace Fmi.Tests.Api.Handlers.Filters
{
    public class AuthActionAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var headers = actionContext.Request.Headers;
            IEnumerable<string> values;
            var token = string.Empty;
            if (headers.TryGetValues(Constants.Headers.AuthTokenHeader, out values))
                token = values.FirstOrDefault();

            if (token != "thetoken")
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);

            base.OnAuthorization(actionContext);
        }
    }
}