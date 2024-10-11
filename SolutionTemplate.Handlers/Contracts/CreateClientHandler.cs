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
    public sealed class CreateClientHandler : ICreateClientHandler
    {
        private readonly IMapper mapper;
        private readonly IValidator<CreateClientRequest> validator;
        private readonly IClientRepository repository;

        public CreateClientHandler(IMapper mapper, IValidator<CreateClientRequest> validator, 
            IClientRepository repository)
        {
            this.mapper = mapper;
            this.validator = validator;
            this.repository = repository;
        }

        public async Task<ActionResponse<ClientResponse>> Handle(CreateClientRequest request, 
            CancellationToken cancellationToken)
        {
            var validationResponse = validator.Validate(request);
            if (!validationResponse.IsValid)
                return validationResponse.ConvertToResponse<ClientResponse>();

            var entity = mapper.Map<Client>(request);

            await repository.Save(entity);

            return ActionResponse<ClientResponse>.Ok();
        }
    }
}
