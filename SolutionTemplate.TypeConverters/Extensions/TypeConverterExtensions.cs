using AutoMapper;
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

        public static IMapper CreateMapperInstance(this MapperConfigurationExpression expression)
        {
            string solutionName = SolutionFactory.BuildName();
            string subProjectName = $"{solutionName}.TypeConverters";
            string profilesNamespace = $"{subProjectName}.Profiles";

            var profiles = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => x.Namespace == profilesNamespace)
                .ToArray();

            var config = new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                    cfg.AddProfile(profile);
            });

            return config.CreateMapper();
        }
    }
}
