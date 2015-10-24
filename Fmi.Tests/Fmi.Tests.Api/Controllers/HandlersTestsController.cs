using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Fmi.Tests.Contracts.Dto;
using Fmi.Tests.Contracts.Requests.Tests;
using Fmi.Tests.Core.Handlers.Interfaces;

namespace Fmi.Tests.Api.Controllers
{
    public class HandlersTestsController : ApiController
    {
        private readonly IMediator _mediator;

        public HandlersTestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("api/handlers/tests")]
        public async Task<HttpResponseMessage> Get()
        {
            var request = new GetAllTestsRequest();
            var response = await _mediator.ExecuteAsync(request).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get([FromUri] string id)
        {
            var request = new GetTestRequest
            {
                Id = id
            };
            var response = await _mediator.ExecuteAsync(request).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Create([FromBody] BasicTestDto test)
        {
            var request = new CreateTestRequest
            {
                Test = test
            };
            await _mediator.ExecuteAsync(request).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Update(string id, [FromBody] BasicTestDto test)
        {
            test.Code = id;
            var request = new CreateTestRequest
            {
                Test = test
            };
            await _mediator.ExecuteAsync(request).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete([FromUri] DeleteTestRequest request)
        {
            await _mediator.ExecuteAsync(request).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpPut]
        [Route("api/handlers/tests/{id}/questions")]
        public async Task<HttpResponseMessage> QuestionIds(string id, [FromBody] List<int> questionIdList)
        {
            var request = new AddExistingTestQuestionsRequest
            {
                QuestionIdList = questionIdList
            };
            await _mediator.ExecuteAsync(request).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpPut]
        [Route("api/handlers/tests/{id}/questions")]
        public async Task<HttpResponseMessage> QuestionsDtos(string id, [FromBody] List<CreateQuestionDto> questionList)
        {
            var request = new AddNewTestQuestionsRequest
            {
                QuestionList = questionList
            };
            await _mediator.ExecuteAsync(request).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}
