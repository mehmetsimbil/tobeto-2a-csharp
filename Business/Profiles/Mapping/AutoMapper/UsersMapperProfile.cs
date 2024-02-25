using AutoMapper;
using Business.Dtos.User;
using Business.Requests.Users;
using Business.Responses.Users;
using Core.Entities;
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
            CreateMap<AddUsersRequest, Userr>();
            CreateMap<Userr, UserListItemDto>();
            
            CreateMap<IList<Userr>, GetUsersListResponse>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));
           
            CreateMap<Userr, DeleteUsersResponse>();
            
            CreateMap<UpdateUsersRequest, Userr>();
            CreateMap<Userr,UpdateUserResponse>();
        }
    }
}
