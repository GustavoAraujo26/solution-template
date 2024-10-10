using SolutionTemplate.Domain.Enums;

namespace SolutionTemplate.Domain.Requests
{
    /// <summary>
    /// Requisicao para listar clientes de forma paginada
    /// </summary>
    public class ListClientsRequest
    {
        /// <summary>
        /// Construtor vazio
        /// </summary>
        public ListClientsRequest() { }

        /// <summary>
        /// Construtor para inicializar as propriedades
        /// </summary>
        /// <param name="status">Status</param>
        /// <param name="nameLike">Nome para comparacao</param>
        /// <param name="page">Numero da pagina</param>
        /// <param name="pageSize">Tamanho da pagina</param>
        public ListClientsRequest(StatusType? status, string? nameLike, int page, int pageSize)
        {
            Status = status;
            NameLike = nameLike;
            Page = page;
            PageSize = pageSize;
        }

        /// <summary>
        /// Status
        /// </summary>
        public StatusType? Status { get; set; }

        /// <summary>
        /// Nome para comparacao
        /// </summary>
        public string? NameLike { get; set; }

        /// <summary>
        /// Numero da pagina
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Tamanho da pagina
        /// </summary>
        public int PageSize { get; set; }
    }
}
