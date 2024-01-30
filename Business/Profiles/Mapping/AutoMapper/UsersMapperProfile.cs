using AutoMapper;
using Business.Dtos.User;
using Business.Requests.Users;
using Business.Responses.Users;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.Mapping.AutoMapper
{
    public class UsersMapperProfile : Profile
    {
        public UsersMapperProfile()
        {
            CreateMap<AddUsersRequest, Users>();
            CreateMap<Users, UserListItemDto>();
            
            CreateMap<IList<Users>, GetUsersListResponse>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));
           
            CreateMap<Users, DeleteUsersResponse>();
            
            CreateMap<UpdateUsersRequest, Users>();
            CreateMap<Users,UpdateUserResponse>();
        }
    }
}
