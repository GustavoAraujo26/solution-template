using ArchitectureTools.Responses;
using AutoMapper;
using FluentValidation;
using SolutionTemplate.Domain.Handlers;
using SolutionTemplate.Domain.Repositories;
using SolutionTemplate.Domain.Requests;
using SolutionTemplate.Domain.Responses;
using SolutionTemplate.Shared.Extensions;

namespace SolutionTemplate.Handlers.Contracts
{
    public sealed class DeleteClientHandler : IDeleteClientHandler
    {
        private readonly IMapper mapper;
        private readonly IClientRepository repository;
        private readonly IValidator<DeleteClientRequest> validator;

        public DeleteClientHandler(IMapper mapper, IClientRepository repository, IValidator<DeleteClientRequest> validator)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.validator = validator;
        }

        public async Task<ActionResponse<ClientResponse>> Handle(DeleteClientRequest request, 
            CancellationToken cancellationToken)
        {
            var validationResponse = validator.Validate(request);
            if (!validationResponse.IsValid)
                return validationResponse.ConvertToResponse<ClientResponse>();

            var entity = await repository.Get(request.Id);
            if (entity is null)
                return ActionResponse<ClientResponse>.NotFound("Cliente nao encontrado.");

            await repository.Delete(request.Id);

            return ActionResponse<ClientResponse>.Ok();
        }
    }
}
