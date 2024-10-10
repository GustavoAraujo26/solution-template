using ArchitectureTools.Pagination;
using SolutionTemplate.Domain.Entites;
using SolutionTemplate.Domain.Repositories;
using SolutionTemplate.Domain.Requests;
using SolutionTemplate.Domain.Responses;

namespace SolutionTemplate.Infra.Contracts
{
    internal class ClientRepository : IClientRepository
    {
        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ClientResponse> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ClientResponse> Get(string name)
        {
            throw new NotImplementedException();
        }

        public Task<PaginationResponse<ClientResponse>> List(ListClientsRequest request)
        {
            throw new NotImplementedException();
        }

        public Task Save(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
