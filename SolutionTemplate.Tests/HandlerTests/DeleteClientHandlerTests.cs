using AutoMapper;
using SolutionTemplate.Handlers.Contracts;
using SolutionTemplate.Tests.Mocks;
using SolutionTemplate.Validations.Contracts;
using SolutionTemplate.TypeConverters.Extensions;
using SolutionTemplate.Tests.FakeData.Requests;
using SolutionTemplate.Domain.Requests;

namespace SolutionTemplate.Tests.HandlerTests
{
    public class DeleteClientHandlerTests
    {
        [Fact]
        public async Task WhenValidRequest_ReturnSuccess()
        {
            var request = DeleteClientRequestFakeData.Build();
            var repository = ClientRepositoryMock.Build(request.Id);
            var mapper = new MapperConfigurationExpression().CreateMapperInstance();
            var validator = new DeleteClientValidator();

            var handler = new DeleteClientHandler(mapper, repository.Object, validator);

            var response = await handler.Handle(request, new CancellationToken());

            Assert.True(response.IsSuccess);
        }

        [Fact]
        public async Task WhenInvalidRequest_ReturnSuccess()
        {
            var request = new DeleteClientRequest();
            var repository = ClientRepositoryMock.Build(request.Id);
            var mapper = new MapperConfigurationExpression().CreateMapperInstance();
            var validator = new DeleteClientValidator();

            var handler = new DeleteClientHandler(mapper, repository.Object, validator);

            var response = await handler.Handle(request, new CancellationToken());

            Assert.False(response.IsSuccess);
        }

        [Fact]
        public async Task WhenClientNotFound_ReturnSuccess()
        {
            var request = DeleteClientRequestFakeData.Build();
            var repository = ClientRepositoryMock.BuildGetNotFound();
            var mapper = new MapperConfigurationExpression().CreateMapperInstance();
            var validator = new DeleteClientValidator();

            var handler = new DeleteClientHandler(mapper, repository.Object, validator);

            var response = await handler.Handle(request, new CancellationToken());

            Assert.False(response.IsSuccess);
        }
    }
}
