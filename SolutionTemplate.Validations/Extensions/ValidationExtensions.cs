using ArchitectureTools.Responses;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using SolutionTemplate.Shared.Factories;
using System.Reflection;

namespace SolutionTemplate.Validations.Extensions
{
    public static class ValidationExtensions
    {
        public static void ConfigureValidations(this IServiceCollection services)
        {
            string solutionName = SolutionFactory.BuildName();
            string validatorNamespace = $"{solutionName}.Validations.Contracts";

            var validator = Assembly.GetExecutingAssembly()
                .GetTypes()
                .First(x => x.Namespace == validatorNamespace);

            services.AddValidatorsFromAssemblyContaining(validator, ServiceLifetime.Transient, includeInternalTypes: true);
        }
    }
}
