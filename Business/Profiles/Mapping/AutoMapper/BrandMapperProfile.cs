

using AutoMapper;
using Business.Dtos.Brand;
using Business.Requests.Brand;
using Business.Responses.Brand;
using Entities.Concrete;

namespace Business.Profiles.Mapping.AutoMapper
{
    public class BrandMapperProfile : Profile
    {
        public BrandMapperProfile()
        {
            CreateMap<AddBrandRequest, Brand>();
            CreateMap<Brand,AddBrandResponse>();

            CreateMap<Brand, BrandListItemDto>();
            CreateMap<BrandListItemDto, GetBrandListResponse>()
                .ForMember(
                destinationMember: dest => dest.Items,
                memberOptions: opt => opt.MapFrom(mapExpression: src => src)
                );
        }
    }
}
