using ArchitectureTools.Responses;
using MediatR;
using SolutionTemplate.Domain.Enums;
using SolutionTemplate.Domain.Responses;

namespace SolutionTemplate.Domain.Requests
{
    /// <summary>
    /// Requisicao para atualizar clientes
    /// </summary>
    public class UpdateClientRequest : IRequest<ActionResponse<ClientResponse>>
    {
        /// <summary>
        /// Construtor vazio
        /// </summary>
        public UpdateClientRequest() { }

        /// <summary>
        /// Construtor para inicializar as propriedades
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="name">Nome</param>
        /// <param name="status">Status</param>
        public UpdateClientRequest(Guid id, string name, StatusType status)
        {
            Id = id;
            Name = name;
            Status = status;
        }

        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public StatusType Status { get; set; }
    }
}
