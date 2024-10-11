using FluentValidation;
using SolutionTemplate.Domain.Requests;

namespace SolutionTemplate.Validations.Contracts
{
    public class ListClientsValidator : AbstractValidator<ListClientsRequest>
    {
        public ListClientsValidator()
        {
            RuleFor(x => x.Page).GreaterThan(0);

            RuleFor(x => x.PageSize).GreaterThan(0);

            RuleFor(x => x.NameLike).MaximumLength(100).When(x => !string.IsNullOrEmpty(x.NameLike));
        }
    }
}
