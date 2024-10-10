using ArchitectureTools.Responses;
using MediatR;
using SolutionTemplate.Domain.Responses;

namespace SolutionTemplate.Domain.Requests
{
    /// <summary>
    /// Requisição para deleção de clientes
    /// </summary>
    public class DeleteClientRequest : IRequest<ActionResponse<ClientResponse>>
    {
        /// <summary>
        /// Construtor vazio
        /// </summary>
        public DeleteClientRequest() { }

        /// <summary>
        /// Construtor para inicializar as propriedades
        /// </summary>
        /// <param name="id">Id</param>
        public DeleteClientRequest(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
    }
}
