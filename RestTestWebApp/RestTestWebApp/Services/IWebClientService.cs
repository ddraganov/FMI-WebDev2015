using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestTestWebApp.Models;

namespace RestTestWebApp.Services
{
    public interface IWebClientService
    {
        TResponse ExecuteGet<TResponse>(ApiRequest request);

        TResponse ExecutePost<TResponse>(ApiRequest request);

        TResponse ExecutePut<TResponse>(ApiRequest request);

        TResponse ExecuteDelete<TResponse>(ApiRequest request);
    }
}