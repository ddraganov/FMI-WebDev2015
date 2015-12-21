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
    public class QuestionsController : Controller
    {
        private readonly IWebClientService webClient;

        public QuestionsController(IWebClientService webClient)
        {
            this.webClient = webClient;
        }

        // GET: Questions
        public ActionResult Index()
        {
            QuestionsListViewModel model = new QuestionsListViewModel();

            model.Items = webClient.ExecuteGet<IEnumerable<QuestionDto>>(new Models.ApiRequest() { EndPoint = "questions?skip=0&take=10" })
                .Select(q => new QuestionsListItem() { Id = q.Id, Text = q.Text }).ToList();

            return View(model);
        }

        // GET: Questions/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Questions/Create
        public ActionResult Create()
        {
            QuestionsDetailsViewModel model = new QuestionsDetailsViewModel();

            model.Answers.Add(new AnswerViewModel() { Text = string.Empty, IsCorrect = false });

            ViewBag.Title = "Create";

            return View(model);
        }

        // POST: Questions/Create
        [HttpPost]
        public ActionResult Create(QuestionsDetailsViewModel model)
        {
            try
            {
                object exisctingTest = webClient.ExecutePost<object>(new Models.ApiRequest()
                {
                    EndPoint = string.Format("questions"),
                    Request = new QuestionDto()
                    {
                        Text = model.Text,
                        Answers = model.Answers.Select(a => new AnswerDto()
                        {
                            IsCorrect = a.IsCorrect,
                            Text = a.Text
                        }).ToList()
                    }
                });

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Questions/Edit/5
        public ActionResult Edit(int id)
        {
            var question = webClient.ExecuteGet<QuestionDto>(new Models.ApiRequest() { EndPoint = string.Format("questions/{0}", id) });

            QuestionsDetailsViewModel model = new QuestionsDetailsViewModel();

            model.Text = question.Text;
            model.Answers = question.Answers.Select(a => new AnswerViewModel() { Text = a.Text, IsCorrect = a.IsCorrect }).ToList();

            ViewBag.Title = "Edit";

            return View("Create", model);
        }

        // POST: Questions/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, QuestionsDetailsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var response = webClient.ExecutePut<object>(new Models.ApiRequest()
                        {
                            EndPoint = string.Format("questions/{0}", model.Id),
                            Request = new QuestionDto()
                            {
                                Text = model.Text,
                                Answers = model.Answers.Select(a => new AnswerDto() { IsCorrect = a.IsCorrect, Text = a.Text }).ToList()
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
            catch
            {
                return View(model);
            }
        }

        // GET: Questions/Delete/5
        public ActionResult Delete(int id)
        {
            webClient.ExecuteDelete(new Models.ApiRequest() { EndPoint = string.Format("questions/{0}", id) });

            return RedirectToAction("Index");
        }

    }
}
