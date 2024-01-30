using Business.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Users
{
    public class GetUsersListResponse
    {
        public ICollection<UserListItemDto> Items { get; set; }
    }
}
