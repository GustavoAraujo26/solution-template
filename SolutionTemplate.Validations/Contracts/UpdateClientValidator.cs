using FluentValidation;
using SolutionTemplate.Domain.Requests;

namespace SolutionTemplate.Validations.Contracts
{
    internal class UpdateClientValidator : AbstractValidator<UpdateClientRequest>
    {
        public UpdateClientValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Continue)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
