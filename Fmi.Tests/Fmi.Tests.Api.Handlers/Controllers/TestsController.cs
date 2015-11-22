using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Fmi.Tests.Contracts.Dto;
using Fmi.Tests.Contracts.Requests.Tests;
using Fmi.Tests.Core.Handlers.Interfaces;

namespace Fmi.Tests.Api.Handlers.Controllers
{
    public class TestsController : ApiController
    {
        private readonly IMediator _mediator;

        public TestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<TestDto>> Get([FromUri] GetAllTestsRequest request)
        {
            return await _mediator.ExecuteAsync(request).ConfigureAwait(false);
        }

        [HttpGet]
        public async Task<TestDto> Get([FromUri] string id)
        {
            var request = new GetTestRequest
            {
                Id = id
            };
            return await _mediator.ExecuteAsync(request).ConfigureAwait(false);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Create([FromBody] TestDto test)
        {
            var request = new CreateTestRequest
            {
                Test = test
            };
            await _mediator.ExecuteAsync(request).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task Update(string id, [FromBody] TestDto test)
        {
            test.Code = id;
            var request = new UpdateTestRequest
            {
                Test = test
            };
            await _mediator.ExecuteAsync(request).ConfigureAwait(false);
        }

        [HttpDelete]
        public async Task Delete([FromUri] DeleteTestRequest request)
        {
            await _mediator.ExecuteAsync(request).ConfigureAwait(false);
        }

        [HttpPut]
        [Route("api/tests/{id}/questions")]
        public async Task QuestionIds(string id, [FromBody] List<int> questionIdList)
        {
            var request = new AddTestQuestionsRequest
            {
                QuestionIdList = questionIdList,
                TestCode = id
            };
            await _mediator.ExecuteAsync(request).ConfigureAwait(false);
        }
    }
}
