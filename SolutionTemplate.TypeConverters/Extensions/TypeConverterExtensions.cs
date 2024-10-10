using Microsoft.Extensions.DependencyInjection;
using SolutionTemplate.Shared.Factories;
using System.Reflection;

namespace SolutionTemplate.TypeConverters.Extensions
{
    public static class TypeConverterExtensions
    {
        public static void ConfigureTypeConverters(this IServiceCollection services)
        {
            string solutionName = SolutionFactory.BuildName();
            string profilesNamespace = $"{solutionName}.TypeConverters.Profiles";

            var profiles = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.Namespace == profilesNamespace)
                .ToArray();

            services.AddAutoMapper(profiles);
        }
    }
}
