using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Fmi.Tests.Contracts.Dto;
using Fmi.Tests.Contracts.Requests.Questions;
using Fmi.Tests.Core.Handlers.Interfaces;

namespace Fmi.Tests.Api.Handlers.Controllers
{
    public class QuestionsController : ApiController
    {
        private readonly IMediator _mediator;

        public QuestionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<QuestionDto>> Get([FromUri] GetAllQuestionsRequest request)
        {
            return await _mediator.ExecuteAsync(request).ConfigureAwait(false);
        }

        [HttpGet]
        public async Task<QuestionDto> Get([FromUri] int id)
        {
            var request = new GetQuestionRequest
            {
                Id = id
            };
            return await _mediator.ExecuteAsync(request).ConfigureAwait(false);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Create([FromBody] QuestionDto question)
        {
            var request = new CreateQuestionRequest
            {
                Question = question
            };
            await _mediator.ExecuteAsync(request).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task Update(int id, [FromBody] QuestionDto question)
        {
            question.Id = id;
            var request = new UpdateQuestionRequest
            {
                Question = question
            };
            await _mediator.ExecuteAsync(request).ConfigureAwait(false);
        }

        [HttpDelete]
        public async Task Delete([FromUri] DeleteQuestionRequest request)
        {
            await _mediator.ExecuteAsync(request).ConfigureAwait(false);
        }

        [HttpGet]
        [Route("api/questions/{id}/iscorrect")]
        public async Task<HttpResponseMessage> IsCorrect([FromUri] CheckQuestionIsCorrectRequest request)
        {
            var isCorrect = await _mediator.ExecuteAsync(request).ConfigureAwait(false);
            var statusCode = isCorrect ? HttpStatusCode.NoContent : HttpStatusCode.NotFound;
            return Request.CreateResponse(statusCode);
        }

        [HttpPost]
        [Route("api/questions/arecorrect")]
        public async Task<Dictionary<int, bool>> AreCorrect(Dictionary<int, int> questionAnswers)
        {
            var request = new CheckQuestionsAreCorrectRequest
            {
                QuestionAnswers = questionAnswers
            };
            return await _mediator.ExecuteAsync(request).ConfigureAwait(false);
        }
    }
}
