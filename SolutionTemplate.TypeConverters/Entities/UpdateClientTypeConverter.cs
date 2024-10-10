using AutoMapper;
using SolutionTemplate.Domain.Entites;
using SolutionTemplate.Domain.Requests;

namespace SolutionTemplate.TypeConverters.Entities
{
    internal class UpdateClientTypeConverter : ITypeConverter<UpdateClientRequest, Client>
    {
        public Client Convert(UpdateClientRequest source, Client destination, ResolutionContext context)
        {
            return new Client(source.Id, source.Name, source.Status);
        }
    }
}
