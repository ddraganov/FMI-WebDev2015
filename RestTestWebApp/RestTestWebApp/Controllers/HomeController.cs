using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fmi.Tests.Contracts.Dto;
using RestTestWebApp.Services;

namespace RestTestWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebClientService webClient;

        public HomeController(IWebClientService webClient)
        {
            this.webClient = webClient;
        }

        public ActionResult Index()
        {
            var response = webClient.ExecuteGet<IEnumerable<TestDto>>(new Models.ApiRequest() { EndPoint = "tests?skip=0&take=10" });

            return View();
        }

        public ActionResult About()
        {
            var response = webClient.ExecutePost<object>(new Models.ApiRequest()
            {
                EndPoint = "tests",
                Request = new TestDto()
                    {
                        AuthToken = "MyToken",
                        Code = "Code 2",
                        Description = "Super nice desctiprion",
                        Name = "Test 2",
                        Questions = new List<QuestionDto>()
                    }
            });

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}