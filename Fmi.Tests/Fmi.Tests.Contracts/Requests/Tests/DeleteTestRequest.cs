namespace Fmi.Tests.Contracts.Requests.Tests
{
    public class DeleteTestRequest : IRequest
    {
        public string Id { get; set; }
        public string AuthToken { get; set; }
    }
}
