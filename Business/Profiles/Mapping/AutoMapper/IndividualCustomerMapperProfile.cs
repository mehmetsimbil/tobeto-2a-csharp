using AutoMapper;
using Business.Dtos.IndividualCustomer;
using Business.Requests.IndividualCustomer;
using Business.Responses.IndividualCustomer;
using Entities.Concrete;


namespace Business.Profiles.Mapping.AutoMapper
{
    public class IndividualCustomerMapperProfile : Profile
    {
        public IndividualCustomerMapperProfile()
        {
            CreateMap<AddIndividualCustomerRequest, IndividualCustomer>();
            CreateMap<IndividualCustomer, IndividualCustomerListItemDto>();
            CreateMap<IList<IndividualCustomer>, GetIndividualCustomerListResponse>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));

            CreateMap<IndividualCustomer, DeleteIndividualCustomerResponse>();
            CreateMap<UpdateIndividualCustomerRequest, IndividualCustomer>();
            CreateMap<IndividualCustomer, UpdateIndividualCustomerResponse>();
        }
    }
}
