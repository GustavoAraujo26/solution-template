using ArchitectureTools.Responses;
using Microsoft.AspNetCore.Diagnostics;

namespace SolutionTemplate.Api.Handlers
{
    /// <summary>
    /// Manipulador global de erros da API
    /// </summary>
    internal sealed class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly Serilog.ILogger _logger;

        public GlobalExceptionHandler(Serilog.ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Realiza tratamento do erro ocorrido
        /// </summary>
        /// <param name="httpContext">Contexto HTTP</param>
        /// <param name="exception">Excecao gerada</param>
        /// <param name="cancellationToken">Token de cancelamento</param>
        /// <returns></returns>
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, 
            CancellationToken cancellationToken)
        {
            _logger.Error(exception, "An error ocurred when execute the request!");

            var appResponse = ActionResponse<object>.InternalError(exception);

            httpContext.Response.StatusCode = appResponse.StatusNumber;
            await httpContext.Response.WriteAsJsonAsync(appResponse, cancellationToken);

            return true;
        }
    }
}
