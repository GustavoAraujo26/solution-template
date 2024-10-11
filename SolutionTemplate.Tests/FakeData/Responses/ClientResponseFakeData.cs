using AutoBogus;
using SolutionTemplate.Domain.Enums;
using SolutionTemplate.Domain.Responses;

namespace SolutionTemplate.Tests.FakeData.Responses
{
    internal static class ClientResponseFakeData
    {
        public static ClientResponse Build(Guid? id = null)
        {
            var faker = new AutoFaker<ClientResponse>();

            faker.RuleFor(x => x.Id, y =>
            {
                if (id.HasValue)
                    return id.Value;
                else
                    return Guid.NewGuid();
            });
            faker.RuleFor(x => x.Name, y => y.Person.FullName);
            faker.RuleFor(x => x.Status, y => y.Random.Enum<StatusType>());

            return faker.Generate();
        }
    }
}
