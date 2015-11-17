using FluentValidation;
using Fmi.Tests.Contracts.Dto;

namespace Fmi.Tests.Contracts.Validators
{
    public class TestValidator : AbstractValidator<TestDto>
    {
        public TestValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
