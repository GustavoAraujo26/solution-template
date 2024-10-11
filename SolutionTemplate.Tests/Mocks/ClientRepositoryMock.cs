using Moq;
using SolutionTemplate.Domain.Entities;
using SolutionTemplate.Domain.Repositories;
using SolutionTemplate.Tests.FakeData.Responses;

namespace SolutionTemplate.Tests.Mocks
{
    internal static class ClientRepositoryMock
    {
        public static IMock<IClientRepository> Build(Guid? id = null)
        {
            var mock = new Mock<IClientRepository>();

            mock.Setup(x => x.Get(It.IsAny<Guid>()))
                .ReturnsAsync(ClientResponseFakeData.Build(id));

            mock.Setup(x => x.Save(It.IsAny<Client>()));

            mock.Setup(x => x.Delete(It.IsAny<Guid>()));

            return mock;
        }

        public static IMock<IClientRepository> BuildGetNotFound()
        {
            var mock = new Mock<IClientRepository>();

            mock.Setup(x => x.Get(It.IsAny<Guid>()));

            return mock;
        }
    }
}
