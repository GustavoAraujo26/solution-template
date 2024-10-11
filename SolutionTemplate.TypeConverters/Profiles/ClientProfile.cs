using AutoMapper;
using SolutionTemplate.Domain.Entities;
using SolutionTemplate.Domain.Requests;
using SolutionTemplate.TypeConverters.Entities;

namespace SolutionTemplate.TypeConverters.Profiles
{
    public class ClientProfile : Profile
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
