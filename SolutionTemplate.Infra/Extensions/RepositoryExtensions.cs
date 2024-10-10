using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using SolutionTemplate.Shared.Factories;

namespace SolutionTemplate.Infra.Extensions
{
    public static class RepositoryExtensions
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            string solutionName = SolutionFactory.BuildName();
            string contractsNamespace = $"{solutionName}.Infra.Contracts";

            services.Scan(scan =>
            {
                scan.FromApplicationDependencies()
                    .AddClasses(classes => classes.InNamespaces(contractsNamespace))
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsImplementedInterfaces()
                    .WithTransientLifetime();
            });
        }
    }
}
