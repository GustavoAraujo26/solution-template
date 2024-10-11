using AutoMapper;
using SolutionTemplate.Handlers.Contracts;
using SolutionTemplate.Tests.FakeData.Requests;
using SolutionTemplate.Tests.Mocks;
using SolutionTemplate.Validations.Contracts;
using SolutionTemplate.TypeConverters.Extensions;
using SolutionTemplate.Domain.Requests;

namespace SolutionTemplate.Tests.HandlerTests
{
    public class UpdateClientHandlerTests
    {
        [Fact]
        public async Task WhenValidRequest_ReturnSuccess()
        {
            var request = UpdateClientRequestFakeData.Build();
            var repository = ClientRepositoryMock.Build(request.Id);
            var mapper = new MapperConfigurationExpression().CreateMapperInstance();
            var validator = new UpdateClientValidator();

            var handler = new UpdateClientHandler(mapper, repository.Object, validator);

            var response = await handler.Handle(request, new CancellationToken());

            Assert.True(response.IsSuccess);
        }

        [Fact]
        public async Task WhenInvalidRequest_ReturnSuccess()
        {
            var request = new UpdateClientRequest();
            var repository = ClientRepositoryMock.Build(request.Id);
            var mapper = new MapperConfigurationExpression().CreateMapperInstance();
            var validator = new UpdateClientValidator();

            var handler = new UpdateClientHandler(mapper, repository.Object, validator);

            var response = await handler.Handle(request, new CancellationToken());

            Assert.False(response.IsSuccess);
        }

        [Fact]
        public async Task WhenClientNotFound_ReturnSuccess()
        {
            var request = UpdateClientRequestFakeData.Build();
            var repository = ClientRepositoryMock.BuildGetNotFound();
            var mapper = new MapperConfigurationExpression().CreateMapperInstance();
            var validator = new UpdateClientValidator();

            var handler = new UpdateClientHandler(mapper, repository.Object, validator);

            var response = await handler.Handle(request, new CancellationToken());

            Assert.False(response.IsSuccess);
        }
    }
}
