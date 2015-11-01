using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Fmi.Tests.Contracts.Dto;
using Fmi.Tests.Core.Services.Interfaces;

namespace Fmi.Tests.Api.Services.Controllers
{
    public class QuestionsController : ApiController
    {
        private readonly IQuestionsService _questionsService;

        public QuestionsController(IQuestionsService questionsService)
        {
            _questionsService = questionsService;
        }

        [HttpGet]
        public async Task<IEnumerable<QuestionDto>> Get(int skip, int take)
        {
            return await _questionsService.Get(skip, take).ConfigureAwait(false);
        }

        [HttpGet]
        public async Task<QuestionDto> Get([FromUri] int id)
        {
            return await _questionsService.Get(id).ConfigureAwait(false);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Create([FromBody] QuestionDto question)
        {
            await _questionsService.Create(question).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task Update(int id, [FromBody] QuestionDto question)
        {
            question.Id = id;
            await _questionsService.Update(question).ConfigureAwait(false);
        }

        [HttpDelete]
        public async Task Delete([FromUri] int id)
        {
            await _questionsService.Delete(id).ConfigureAwait(false);
        }

        [HttpGet]
        [Route("api/questions/{id}/iscorrect")]
        public async Task<HttpResponseMessage> IsCorrect(int id, int answer)
        {
            var isCorrect = await _questionsService.IsCorrect(id, answer).ConfigureAwait(false);
            var statusCode = isCorrect ? HttpStatusCode.NoContent : HttpStatusCode.NotFound;
            return Request.CreateResponse(statusCode);
        }

        [HttpPost]
        [Route("api/questions/arecorrect")]
        public async Task<Dictionary<int, bool>> AreCorrect(Dictionary<int, int> questionAnswers)
        {
            return await _questionsService.AreCorrect(questionAnswers).ConfigureAwait(false);
        }
    }
}
