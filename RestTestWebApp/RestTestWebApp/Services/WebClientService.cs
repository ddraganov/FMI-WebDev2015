using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using Fmi.Tests.Contracts;
using Newtonsoft.Json;
using RestTestWebApp.Models;

namespace RestTestWebApp.Services
{
    public class WebClientService : IWebClientService
    {
        IConfigurationService configurationService;

        public WebClientService(IConfigurationService configurationService)
        {
            this.configurationService = configurationService;
        }

        public TResponse ExecuteGet<TResponse>(ApiRequest request)
        {
            try
            {
                using (HttpClient client = GetHttpClient())
                {
                    using (var response = client.GetAsync(request.EndPoint).GetAwaiter().GetResult())
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            return JsonConvert.DeserializeObject<TResponse>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                        }

                        return default(TResponse);
                    }
                }
            }
            catch
            {
                return default(TResponse);
            }
        }

        public TResponse ExecutePost<TResponse>(ApiRequest request)
        {
            try
            {
                using (HttpClient client = GetHttpClient())
                {
                    using (StringContent requestContent = new StringContent(request.Request != null ? JsonConvert.SerializeObject(request.Request) : string.Empty, Encoding.UTF8, "application/json"))
                    {
                        using (var response = client.PostAsync(request.EndPoint, requestContent).GetAwaiter().GetResult())
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                return JsonConvert.DeserializeObject<TResponse>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                            }

                            return default(TResponse);
                        }
                    }
                }
            }
            catch
            {
                return default(TResponse);
            }
        }

        public TResponse ExecutePut<TResponse>(ApiRequest request)
        {
            try
            {
                using (HttpClient client = GetHttpClient())
                {
                    using (StringContent requestContent = new StringContent(request.Request != null ? JsonConvert.SerializeObject(request.Request) : string.Empty, Encoding.UTF8, "application/json"))
                    {
                        using (var response = client.PutAsync(request.EndPoint, requestContent).GetAwaiter().GetResult())
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                return JsonConvert.DeserializeObject<TResponse>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                            }

                            return default(TResponse);
                        }
                    }
                }
            }
            catch
            {
                return default(TResponse);
            }
        }

        public void ExecuteDelete(ApiRequest request)
        {
            try
            {
                using (HttpClient client = GetHttpClient())
                {
                    using (var response = client.DeleteAsync(request.EndPoint).GetAwaiter().GetResult())
                    {
                        response.EnsureSuccessStatusCode();
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private HttpClient GetHttpClient()
        {
            HttpClientHandler handler = new HttpClientHandler();

            if(handler.SupportsAutomaticDecompression)
            {
                handler.AutomaticDecompression = DecompressionMethods.GZip;
            }

            HttpClient client = new HttpClient(handler);

            client.BaseAddress = new Uri(configurationService.GetValue("ApiBaseUrl"));

            client.Timeout = TimeSpan.FromSeconds(20);
            
            if (handler.SupportsAutomaticDecompression)
            {
                client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");
                client.DefaultRequestHeaders.Add("Auth-Token", "thetoken");
            }

            return client;
        }
    }
}