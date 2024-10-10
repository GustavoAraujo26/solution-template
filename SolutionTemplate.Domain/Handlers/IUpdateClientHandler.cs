using ArchitectureTools.Responses;
using MediatR;
using SolutionTemplate.Domain.Requests;
using SolutionTemplate.Domain.Responses;

namespace SolutionTemplate.Domain.Handlers
{
    /// <summary>
    /// Interface do manipulador de atualização de clientes
    /// </summary>
    public interface IUpdateClientHandler : IRequestHandler<UpdateClientRequest, ActionResponse<ClientResponse>>
    {
    }
}
