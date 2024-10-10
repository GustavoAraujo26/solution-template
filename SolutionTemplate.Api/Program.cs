using Asp.Versioning.ApiExplorer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using Serilog;
using SolutionTemplate.Api.Extensions;
using SolutionTemplate.Api.Handlers;
using SolutionTemplate.Handlers.Extensions;
using SolutionTemplate.Infra.Extensions;
using SolutionTemplate.TypeConverters.Extensions;
using SolutionTemplate.Validations.Extensions;

namespace SolutionTemplate.Api
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class Program
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public static void Main(string[] args)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.ConfigureAppLogging();
            builder.Services.ConfigureHandlers();
            builder.Services.ConfigureTypeConverters();
            builder.Services.ConfigureRepositories();
            builder.Services.ConfigureValidations();

            builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.EnableAnnotations();
                
                List<string> xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList();
                xmlFiles.ForEach(xmlFile => options.IncludeXmlComments(xmlFile));
            });

            builder.Services.ConfigureAppVersioning();

            builder.Services.AddCors();

            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddProblemDetails();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());

                    options.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection();

            app.UseSerilogRequestLogging();

            app.UseExceptionHandler();

            app.MapControllers();

            app.UseCors(options =>
            {
                options.AllowAnyHeader();
                options.AllowAnyMethod();
                options.AllowAnyOrigin();
            });

            app.Run();
        }
    }
}
