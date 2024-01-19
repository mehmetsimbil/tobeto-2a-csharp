using AutoMapper;
using Business.Dtos.Transmission;
using Business.Requests.Transmission;
using Business.Responses.Transmission;
using Entities.Concrete;


namespace Business.Profiles.Mapping.AutoMapper
{
    public class TransmissionMapperProfile : Profile
    {
        public TransmissionMapperProfile()
        {
            CreateMap<AddTransmissionRequest, Fuel>();
            CreateMap<Fuel, AddTransmissionResponse>();

            CreateMap<Transmission, TransmissionListItemDto>();
            CreateMap<IList<Transmission>, GetTransmissionListResponse>().ForMember(
                destinationMember: dest => dest.Items,
                memberOptions: opt => opt.MapFrom(mapExpression: src => src)
                );

        }
    }
}
