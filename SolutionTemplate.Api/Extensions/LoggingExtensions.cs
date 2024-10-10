using Serilog;
using Serilog.Events;
using SolutionTemplate.Shared.Factories;

namespace SolutionTemplate.Api.Extensions
{
    /// <summary>
    /// Extensões relacionadas a logging
    /// </summary>
    internal static class LoggingExtensions
    {
        /// <summary>
        /// Configura a injeção de dependência para o logger do Serilog
        /// </summary>
        /// <param name="builder">Construtor da aplicação</param>
        public static void ConfigureAppLogging(this WebApplicationBuilder builder)
        {
            var logger = CreateAppLogger();

            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);
            builder.Host.UseSerilog(logger);
        }

        /// <summary>
        /// Cria uma nova instância do logger do Serilog
        /// </summary>
        /// <returns>Interface do logger do Serilog</returns>
        public static Serilog.ILogger CreateAppLogger()
        {
            var newLogger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                .MinimumLevel.Override("System", LogEventLevel.Information)
                .WriteTo.Console()
                .WriteTo.File($"{SolutionFactory.BuildName()}.txt")
                .CreateLogger();

            return newLogger;
        }
    }
}
