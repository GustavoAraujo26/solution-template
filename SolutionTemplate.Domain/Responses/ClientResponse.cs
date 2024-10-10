using SolutionTemplate.Domain.Enums;

namespace SolutionTemplate.Domain.Responses
{
    /// <summary>
    /// Resposta de cliente
    /// </summary>
    public class ClientResponse
    {
        /// <summary>
        /// Construtor Vazio
        /// </summary>
        public ClientResponse() { }

        /// <summary>
        /// Construtor para inicializar as propriedades
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="name">Nome</param>
        /// <param name="status">Status</param>
        public ClientResponse(Guid id, string? name, StatusType status)
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
