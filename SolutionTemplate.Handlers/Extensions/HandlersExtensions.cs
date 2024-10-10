using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using SolutionTemplate.Shared.Factories;
using System.Reflection;

namespace SolutionTemplate.Handlers.Extensions
{
    public static class HandlersExtensions
    {
        public static void ConfigureHandlers(this IServiceCollection services)
        {
            string solutionName = SolutionFactory.BuildName();
            string contractsNamespace = $"{solutionName}.Handlers.Contracts";

            var configuration = new MediatRServiceConfiguration();
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(configuration);

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
