using FluentValidation;
using SolutionTemplate.Domain.Requests;

namespace SolutionTemplate.Validations.Contracts
{
    internal class DeleteClientValidator : AbstractValidator<DeleteClientRequest>
    {
        public DeleteClientValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }
}
