using AutoMapper;
using SolutionTemplate.Domain.Entites;
using SolutionTemplate.Domain.Requests;
using SolutionTemplate.TypeConverters.Entities;

namespace SolutionTemplate.TypeConverters.Profiles
{
    internal class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<CreateClientRequest, Client>()
                .ConvertUsing<CreateClientTypeConverter>();

            CreateMap<UpdateClientRequest, Client>()
                .ConvertUsing<UpdateClientTypeConverter>();
        }
    }
}
