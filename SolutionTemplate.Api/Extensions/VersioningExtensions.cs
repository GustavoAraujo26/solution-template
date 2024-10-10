using Asp.Versioning;
using SolutionTemplate.Api.Providers;

namespace SolutionTemplate.Api.Extensions
{
    /// <summary>
    /// Extensões para versionamento de API
    /// </summary>
    internal static class VersioningExtensions
    {
        /// <summary>
        /// Configura o versionamento da API na injeção de dependência
        /// </summary>
        /// <param name="services">Interface da coleção de serviços</param>
        public static void ConfigureAppVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
                options.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                    new HeaderApiVersionReader("x-api-version"),
                    new MediaTypeApiVersionReader("x-api-version"));
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.ConfigureOptions<ConfigureSwaggerOptions>();
        }
    }
}
