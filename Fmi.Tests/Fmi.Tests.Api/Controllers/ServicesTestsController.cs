using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Fmi.Tests.Contracts.Dto;
using Fmi.Tests.Core.Services.Interfaces;

namespace Fmi.Tests.Api.Controllers
{
    public class ServicesTestsController : ApiController
    {
        private readonly ITestsService _testsService;

        public ServicesTestsController(ITestsService testsService)
        {
            _testsService = testsService;
        }

        [HttpGet]
        [Route("api/services/tests")]
        public async Task<HttpResponseMessage> Get()
        {
            var response = await _testsService.Get().ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get([FromUri] string id)
        {
            var response = await _testsService.Get(id).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Create([FromBody] BasicTestDto test)
        {
            await _testsService.Create(test).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Update(string id, [FromBody] BasicTestDto test)
        {
            test.Code = id;
            await _testsService.Update(test).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete([FromUri] string id)
        {
            await _testsService.Delete(id).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpPut]
        [Route("api/services/tests/{id}/questions")]
        public async Task<HttpResponseMessage> QuestionIds(string id, [FromBody] List<int> questionIdList)
        {
            await _testsService.AddQuestions(id, questionIdList).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpPut]
        [Route("api/services/tests/{id}/questions")]
        public async Task<HttpResponseMessage> QuestionsDtos(string id, [FromBody] List<CreateQuestionDto> questionList)
        {
            await _testsService.AddQuestions(id, questionList).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}
