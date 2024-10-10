using ArchitectureTools.Responses;
using MediatR;
using SolutionTemplate.Domain.Requests;
using SolutionTemplate.Domain.Responses;

namespace SolutionTemplate.Domain.Handlers
{
    /// <summary>
    /// Interface do manipulador de deleção de clientes
    /// </summary>
    public interface IDeleteClientHandler : IRequestHandler<DeleteClientRequest, ActionResponse<ClientResponse>>
    {
    }
}
