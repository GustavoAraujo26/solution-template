using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using SolutionTemplate.Shared.Factories;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SolutionTemplate.Api.Providers
{
    /// <summary>
    /// Configuração do Swagger para versionamento de API
    /// </summary>
    internal class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            this.provider = provider;
        }

        /// <summary>
        /// Realiza configuracao
        /// </summary>
        /// <param name="name">Nome</param>
        /// <param name="options">Opções de configuração</param>
        public void Configure(string name, SwaggerGenOptions options)
        {
            Configure(options);
        }

        /// <summary>
        /// Realiza configuracao
        /// </summary>
        /// <param name="options">Opções de configuração</param>
        public void Configure(SwaggerGenOptions options)
        {
            options.SwaggerGeneratorOptions.SwaggerDocs.Clear();

            foreach (var description in provider.ApiVersionDescriptions)
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
        }

        private OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
        {
            string solutionName = SolutionFactory.BuildName();
            
            var info = new OpenApiInfo()
            {
                Title = solutionName,
                Version = description.ApiVersion.ToString(),
                Description = "Inserir aqui a descrição da API",
                Contact = new OpenApiContact
                {
                    Email = "gustavo.dearaujo26@gmail.com",
                    Url = new Uri("https://github.com/GustavoAraujo26")
                }
            };

            if (description.IsDeprecated)
                info.Description += " This API version has been deprecated. Please use one of the new APIS available from explorer.";

            return info;
        }
    }
}
