using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fmi.Tests.Contracts.Dto;
using RestTestWebApp.Services;
using RestTestWebApp.ViewModels;

namespace RestTestWebApp.Controllers
{
    public class TestsController : Controller
    {
        private readonly IWebClientService webClient;

        public TestsController(IWebClientService webClient)
        {
            this.webClient = webClient;
        }

        // GET: Tests
        public ActionResult Index()
        {
            TestsListViewModel model = new TestsListViewModel();

            model.Items = webClient.ExecuteGet<IEnumerable<TestDto>>(new Models.ApiRequest() { EndPoint = "tests?skip=0&take=10" })
                .Select(r => new TestBaseItem(){ Code = r.Code, Name = r.Name }).ToList();

            return View(model);
        }
        
        // GET: Tests/Create
        public ActionResult Create()
        {
            TestDetailsViewModel model = new TestDetailsViewModel();

            return View(model);
        }

        // POST: Tests/Create
        [HttpPost]
        public ActionResult Create(TestDetailsViewModel model)
        {
            TestDto exisctingTest = webClient.ExecuteGet<TestDto>(new Models.ApiRequest() { EndPoint = string.Format("tests/{0}", model.Code) });

            if(exisctingTest != null)
            {
                ModelState.AddModelError("Code", "Code already exists");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var response = webClient.ExecutePost<object>(new Models.ApiRequest()
                    {
                        EndPoint = "tests",
                        Request = new TestDto()
                        {
                            AuthToken = model.AuthToken ?? "MyToken",
                            Code = model.Code,
                            Description = model.Desctiption,
                            Name = model.Name,
                            Questions = new List<QuestionDto>()
                        }
                    });

                    return RedirectToAction("Edit", new { id = model.Code });
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("generalError", e.Message);

                    return View(model);
                }
            }

            return View(model);
        }

        // GET: Tests/Edit/5
        public ActionResult Edit(string id)
        {
            TestDetailsViewModel model = new TestDetailsViewModel();

            TestDto response = webClient.ExecuteGet<TestDto>(new Models.ApiRequest() { EndPoint = string.Format("tests/{0}", id) });

            model.AuthToken = response.AuthToken;
            model.Code = response.Code;
            model.Name = response.Name;
            model.Desctiption = response.Description;
            model.SelectedQuestions = response.Questions.Select(q => new SelectListItem()
            {
                Selected = false,
                Text = q.Text,
                Value = q.Id.ToString()
            }).ToList();

            model.AvailableQuiestions = webClient.ExecuteGet<IEnumerable<QuestionDto>>(new Models.ApiRequest() { EndPoint = string.Format("questions?skip=0&take={0}", int.MaxValue - 1) })
                .Select(q => new SelectListItem()
                {
                    Selected = false,
                    Text = q.Text,
                    Value = q.Id.ToString()
                }).ToList();

            return View(model);
        }

        // POST: Tests/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, TestDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = webClient.ExecutePut<object>(new Models.ApiRequest()
                    {
                        EndPoint = string.Format("tests/{0}", model.Code),
                        Request = new TestDto()
                        {
                            AuthToken = model.AuthToken ?? "MyToken",
                            Code = model.Code,
                            Description = model.Desctiption,
                            Name = model.Name,
                            Questions = model.QuestionIds.Select(q => new QuestionDto() { Id = q }).ToList()
                        }
                    });

                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("generalError", e.Message);

                    return View(model);
                }
            }

            return View(model);
        }

        // GET: Tests/Delete/5
        public ActionResult Delete(string id)
        {
            webClient.ExecuteDelete(new Models.ApiRequest() { EndPoint = string.Format("tests/{0}", id) });

            return RedirectToAction("Index");
        }

    }
}
