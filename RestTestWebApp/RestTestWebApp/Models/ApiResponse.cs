using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace RestTestWebApp.Models
{
    public class ApiResponse<TResponse> where TResponse : new()
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        public TResponse Payload { get; set; }
    }
}