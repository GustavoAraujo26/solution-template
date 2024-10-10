using AutoMapper;
using SolutionTemplate.Domain.Entites;
using SolutionTemplate.Domain.Enums;
using SolutionTemplate.Domain.Requests;

namespace SolutionTemplate.TypeConverters.Entities
{
    internal class CreateClientTypeConverter : ITypeConverter<CreateClientRequest, Client>
    {
        public Client Convert(CreateClientRequest source, Client destination, ResolutionContext context)
        {
            return new Client(Guid.NewGuid(), source.Name, StatusType.Enabled);
        }
    }
}
