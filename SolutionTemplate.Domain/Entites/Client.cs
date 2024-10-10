using SolutionTemplate.Domain.Enums;

namespace SolutionTemplate.Domain.Entites
{
    /// <summary>
    /// Entidade cliente
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Construtor vazio
        /// </summary>
        public Client() { }

        /// <summary>
        /// Construtor para inicializar as propriedades
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="name">Nome</param>
        /// <param name="status">Status</param>
        public Client(Guid id, string? name, StatusType status)
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
