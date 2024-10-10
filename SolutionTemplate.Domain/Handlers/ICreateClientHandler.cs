using ArchitectureTools.Responses;
using MediatR;
using SolutionTemplate.Domain.Requests;
using SolutionTemplate.Domain.Responses;

namespace SolutionTemplate.Domain.Handlers
{
    /// <summary>
    /// Interface do manipulador de criação de clientes
    /// </summary>
    public interface ICreateClientHandler : IRequestHandler<CreateClientRequest, ActionResponse<ClientResponse>>
    {
    }
}
