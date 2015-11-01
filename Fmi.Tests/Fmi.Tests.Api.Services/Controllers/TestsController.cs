using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using Fmi.Tests.Contracts;
using Fmi.Tests.Contracts.Dto;
using Fmi.Tests.Core.Services.Interfaces;

namespace Fmi.Tests.Api.Services.Controllers
{
    public class TestsController : ApiController
    {
        private readonly ITestsService _testsService;

        private string _authToken;

        public TestsController(ITestsService testsService)
        {
            _testsService = testsService;
        }

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);

            var headers = controllerContext.Request.Headers;
            IEnumerable<string> values;
            if (headers.TryGetValues(Constants.Headers.AuthTokenHeader, out values))
                _authToken = values.FirstOrDefault();
        }

        [HttpGet]
        public async Task<IEnumerable<TestDto>> Get(int skip, int take)
        {
            return await _testsService.Get(skip, take).ConfigureAwait(false);
        }

        [HttpGet]
        public async Task<TestDto> Get([FromUri] string id)
        {
            return await _testsService.Get(id).ConfigureAwait(false);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Create([FromBody] TestDto test)
        {
            await _testsService.Create(test).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task Update(string id, [FromBody] TestDto test)
        {
            test.Code = id;
            await _testsService.Update(test, _authToken).ConfigureAwait(false);
        }

        [HttpDelete]
        public async Task Delete([FromUri] string id)
        {
            await _testsService.Delete(id, _authToken).ConfigureAwait(false);
        }

        [HttpPut]
        [Route("api/tests/{id}/questions")]
        public async Task QuestionIds(string id, [FromBody] List<int> questionIdList)
        {
            await _testsService.AddQuestions(id, questionIdList, _authToken).ConfigureAwait(false);
        }
    }
}
