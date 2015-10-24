using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Fmi.Tests.Contracts.Dto;
using Fmi.Tests.Core.Services.Interfaces;

namespace Fmi.Tests.Api.Controllers
{
    public class ServicesQuestionsController : ApiController
    {
        private readonly IQuestionsService _questionsService;

        public ServicesQuestionsController(IQuestionsService questionsService)
        {
            _questionsService = questionsService;
        }

        [HttpGet]
        [Route("api/services/questions")]
        public async Task<HttpResponseMessage> Get()
        {
            var response = await _questionsService.Get().ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get([FromUri] int id)
        {
            var response = await _questionsService.Get(id).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Create([FromBody] CreateQuestionDto question)
        {
            await _questionsService.Create(question).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Update(int id, [FromBody] QuestionDto question)
        {
            question.Id = id;
            await _questionsService.Update(question).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete([FromUri] int id)
        {
            await _questionsService.Delete(id).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}
