using ArchitectureTools.Responses;
using MediatR;
using SolutionTemplate.Domain.Responses;

namespace SolutionTemplate.Domain.Requests
{
    /// <summary>
    /// Requisicao para criação de clientes
    /// </summary>
    public class CreateClientRequest : IRequest<ActionResponse<ClientResponse>>
    {
        /// <summary>
        /// Construtor vazio
        /// </summary>
        public CreateClientRequest() { }

        /// <summary>
        /// Construtor para inicializar as propriedades
        /// </summary>
        /// <param name="name">Nome</param>
        public CreateClientRequest(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Nome
        /// </summary>
        public string? Name { get; set; }
    }
}
