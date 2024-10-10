using ArchitectureTools.Responses;
using AutoMapper;
using FluentValidation;
using SolutionTemplate.Domain.Entites;
using SolutionTemplate.Domain.Handlers;
using SolutionTemplate.Domain.Repositories;
using SolutionTemplate.Domain.Requests;
using SolutionTemplate.Domain.Responses;
using SolutionTemplate.Shared.Extensions;

namespace SolutionTemplate.Handlers.Contracts
{
    public class UpdateClientHandler : IUpdateClientHandler
    {
        private readonly IMapper mapper;
        private readonly IClientRepository repository;
        private readonly IValidator<UpdateClientRequest> validator;

        public UpdateClientHandler(IMapper mapper, IClientRepository repository, 
            IValidator<UpdateClientRequest> validator)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.validator = validator;
        }

        public async Task<ActionResponse<ClientResponse>> Handle(UpdateClientRequest request, 
            CancellationToken cancellationToken)
        {
            var validationResponse = validator.Validate(request);
            if (!validationResponse.IsValid)
                return validationResponse.ConvertToResponse<ClientResponse>();

            var currentClient = await repository.Get(request.Id);
            if (currentClient is null)
                return ActionResponse<ClientResponse>.NotFound("Cliente nao encontrado.");

            var entity = mapper.Map<Client>(request);

            await repository.Save(entity);

            return ActionResponse<ClientResponse>.Ok();
        }
    }
}
