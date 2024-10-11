using AutoBogus;
using SolutionTemplate.Domain.Requests;

namespace SolutionTemplate.Tests.FakeData.Requests
{
    internal static class DeleteClientRequestFakeData
    {
        public static DeleteClientRequest Build()
        {
            var faker = new AutoFaker<DeleteClientRequest>();

            faker.RuleFor(x => x.Id, y => Guid.NewGuid());

            return faker.Generate();
        }
    }
}
