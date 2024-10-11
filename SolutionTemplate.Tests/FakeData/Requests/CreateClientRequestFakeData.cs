using AutoBogus;
using SolutionTemplate.Domain.Requests;

namespace SolutionTemplate.Tests.FakeData.Requests
{
    internal static class CreateClientRequestFakeData
    {
        public static CreateClientRequest Build()
        {
            var faker = new AutoFaker<CreateClientRequest>();

            faker.RuleFor(x => x.Name, y => y.Person.FullName);

            return faker.Generate();
        }
    }
}
