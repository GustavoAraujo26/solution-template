using AutoBogus;
using SolutionTemplate.Domain.Enums;
using SolutionTemplate.Domain.Requests;

namespace SolutionTemplate.Tests.FakeData.Requests
{
    internal static class UpdateClientRequestFakeData
    {
        public static UpdateClientRequest Build()
        {
            var faker = new AutoFaker<UpdateClientRequest>();

            faker.RuleFor(x => x.Id, x => Guid.NewGuid());
            faker.RuleFor(x => x.Name, y => y.Person.FullName);
            faker.RuleFor(x => x.Status, y => y.Random.Enum<StatusType>());

            return faker.Generate();
        }
    }
}
