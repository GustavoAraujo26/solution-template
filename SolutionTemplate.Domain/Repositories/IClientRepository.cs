using ArchitectureTools.Pagination;
using SolutionTemplate.Domain.Entities;
using SolutionTemplate.Domain.Requests;
using SolutionTemplate.Domain.Responses;

namespace SolutionTemplate.Domain.Repositories
{
    /// <summary>
    /// Interface do repositorio de clientes
    /// </summary>
    public interface IClientRepository
    {
        /// <summary>
        /// Salva dados do cliente
        /// </summary>
        /// <param name="client">Dados do cliente</param>
        /// <returns>Container-resposta</returns>
        Task Save(Client client);

        /// <summary>
        /// Apaga cliente
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        Task Delete(Guid id);

        /// <summary>
        /// Busca cliente pelo Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Dados do cliente</returns>
        Task<ClientResponse> Get(Guid id);

        /// <summary>
        /// Busca cliente pelo nome
        /// </summary>
        /// <param name="name">Nome</param>
        /// <returns>Dados do cliente</returns>
        Task<ClientResponse> Get(string name);

        /// <summary>
        /// Lista clientes de forma paginada
        /// </summary>
        /// <param name="request">Dados da paginacao</param>
        /// <returns>Lista de clientes paginada</returns>
        Task<PaginationResponse<ClientResponse>> List(ListClientsRequest request);
    }
}
