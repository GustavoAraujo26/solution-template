using ArchitectureTools.Responses;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SolutionTemplate.Api.Controllers.Base;
using SolutionTemplate.Domain.Repositories;
using SolutionTemplate.Domain.Requests;
using SolutionTemplate.Domain.Responses;
using Swashbuckle.AspNetCore.Annotations;

namespace SolutionTemplate.Api.Controllers
{
    /// <summary>
    /// Controlador de clientes (Exemplo)
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [SwaggerTag("Ações relacionadas ao cadastro de clientes")]
    public class ClientsController : BaseController
    {
        /// <summary>
        /// Lista clientes
        /// </summary>
        /// <param name="request">Dados da requisição</param>
        /// <param name="repository">Interface do repositorio</param>
        /// <returns>JSON</returns>
        [HttpGet]
        [Route("list")]
        public async Task<ActionResult> List([FromQuery] ListClientsRequest request,
            [FromServices] IClientRepository repository)
        {
            var response = await repository.List(request);

            return BuildResponse(response);
        }

        /// <summary>
        /// Busca cliente com base no ID ou no nome
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="name">Nome</param>
        /// <param name="repository">Interface do repositorio</param>
        /// <returns>JSON</returns>
        [HttpGet]
        public async Task<ActionResult> GetBy([FromQuery] Guid? id, [FromQuery] string name,
            [FromServices] IClientRepository repository)
        {
            ClientResponse response = new();

            if (!id.HasValue && string.IsNullOrEmpty(name))
                return BuildResponse(ActionResponse<ClientResponse>.BadRequest("Parametros sao obrigatorios!"));

            if (id.HasValue)
            {
                response = await repository.Get(id.Value);
                return BuildResponse(response);
            }
            
            response = await repository.Get(name);
            return BuildResponse(response);
        }

        /// <summary>
        /// Apaga cliente
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="mediator">Interface do mediator</param>
        /// <returns>JSON</returns>
        [HttpDelete]
        public async Task<ActionResult> Delete([FromRoute] Guid id,
            [FromServices] IMediator mediator)
        {
            var request = new DeleteClientRequest(id);
            var response = await mediator.Send(request);

            return BuildResponse(response);
        }

        /// <summary>
        /// Cria novo cliente
        /// </summary>
        /// <param name="request">Dados da requisicao</param>
        /// <param name="mediator">Interface do mediator</param>
        /// <returns>JSON</returns>
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateClientRequest request,
            [FromServices] IMediator mediator)
        {
            var response = await mediator.Send(request);

            return BuildResponse(response);
        }

        /// <summary>
        /// Atualiza dados do cliente
        /// </summary>
        /// <param name="request">Dados da requisicao</param>
        /// <param name="mediator">Interface do mediator</param>
        /// <returns>JSON</returns>
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateClientRequest request,
            [FromServices] IMediator mediator)
        {
            var response = await mediator.Send(request);

            return BuildResponse(response);
        }
    }
}
