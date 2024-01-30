using AutoMapper;
using Business.Dtos.Customer;
using Business.Requests.Customer;
using Business.Responses.Customer;
using Entities.Concrete;


namespace Business.Profiles.Mapping.AutoMapper
{
    public class CustomerMapperProfile : Profile
    {
        public CustomerMapperProfile()
        {
            CreateMap<AddCustomerRequest, Customers>();
            CreateMap<Customers, CustomerListItemDto>();
            CreateMap<IList<Customers>, GetCustomerListResponse>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));

            CreateMap<Customers, DeleteCustomerResponse>();

            CreateMap<UpdateCustomerRequest,Customers>();
            CreateMap<Customers,UpdateCustomerResponse>();
        }
    }
}
