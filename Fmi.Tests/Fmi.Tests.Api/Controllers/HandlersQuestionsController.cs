using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Fmi.Tests.Contracts.Dto;
using Fmi.Tests.Contracts.Requests.Questions;
using Fmi.Tests.Core.Handlers.Interfaces;

namespace Fmi.Tests.Api.Controllers
{
    public class HandlersQuestionsController : ApiController
    {
        private readonly IMediator _mediator;

        public HandlersQuestionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("api/handlers/questions")]
        public async Task<HttpResponseMessage> Get()
        {
            var request = new GetAllQuestionsRequest();
            var response = await _mediator.ExecuteAsync(request).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get([FromUri] int id)
        {
            var request = new GetQuestionRequest
            {
                Id = id
            };
            var response = await _mediator.ExecuteAsync(request).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Create([FromBody] CreateQuestionDto question)
        {
            var request = new CreateQuestionRequest
            {
                Question = question
            };
            await _mediator.ExecuteAsync(request).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Update(int id, [FromBody] QuestionDto question)
        {
            question.Id = id;
            var request = new CreateQuestionRequest
            {
                Question = question
            };
            await _mediator.ExecuteAsync(request).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete([FromUri] DeleteQuestionRequest request)
        {
            await _mediator.ExecuteAsync(request).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}
