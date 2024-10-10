using ArchitectureTools.Responses;
using FluentValidation.Results;

namespace SolutionTemplate.Shared.Extensions
{
    public static class ValidationExtensions
    {
        public static ActionResponse<T> ConvertToResponse<T>(this ValidationResult? validationResult)
        {
            if (validationResult == null)
                throw new ArgumentNullException("Validation return null!");
            
            var errors = validationResult.Errors.Select(x => $"{x.PropertyName}: {x.ErrorMessage}").ToList();
            if (errors.Count == 0)
                throw new ArgumentNullException("Validation errors empty!");

            return ActionResponse<T>.UnprocessableEntity(errors);
        }
    }
}
