using SolutionTemplate.Tests.FakeData.Requests;
using SolutionTemplate.Tests.Mocks;
using SolutionTemplate.Handlers.Contracts;
using SolutionTemplate.Validations.Contracts;
using AutoMapper;
using SolutionTemplate.TypeConverters.Extensions;
using SolutionTemplate.Domain.Requests;

namespace SolutionTemplate.Tests.HandlerTests
{
    public class CreateClientHandlerTests
    {
        [Fact]
        public async Task WhenValidRequest_ReturnSuccess()
        {
            var request = CreateClientRequestFakeData.Build();
            var repository = ClientRepositoryMock.Build();
            var mapper = new MapperConfigurationExpression().CreateMapperInstance();
            var validator = new CreateClientValidator();

            var handler = new CreateClientHandler(mapper, validator, repository.Object);

            var response = await handler.Handle(request, new CancellationToken());

            Assert.True(response.IsSuccess);
        }

        [Fact]
        public async Task WhenInvalidRequest_ReturnSuccess()
        {
            var request = new CreateClientRequest();
            var repository = ClientRepositoryMock.Build();
            var mapper = new MapperConfigurationExpression().CreateMapperInstance();
            var validator = new CreateClientValidator();

            var handler = new CreateClientHandler(mapper, validator, repository.Object);

            var response = await handler.Handle(request, new CancellationToken());

            Assert.False(response.IsSuccess);
        }
    }
}
