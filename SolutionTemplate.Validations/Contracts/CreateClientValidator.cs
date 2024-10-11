using FluentValidation;
using SolutionTemplate.Domain.Requests;

namespace SolutionTemplate.Validations.Contracts
{
    public class CreateClientValidator : AbstractValidator<CreateClientRequest>
    {
        public CreateClientValidator()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Continue)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
