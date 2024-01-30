using Business.Requests.Users;
using Business.Responses.Users;


namespace Business.Abstract
{
    public interface IUsersService
    {
        public GetUsersListResponse GetList(GetUsersListRequest request);
        public AddUsersResponse Add(AddUsersRequest request);
        public UpdateUserResponse Update(UpdateUsersRequest request);
        public DeleteUsersResponse Delete(DeleteUsersRequest request);
    }
}
