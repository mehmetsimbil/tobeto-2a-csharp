using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Profiles.Validation.FluentValidation.Users;
using Business.Requests.Users;
using Business.Responses.Users;
using Core.CrossCuttingConcerns.Validation.FluentValidaton;
using DataAccess.Abstract;
using Entities.Concrete;


namespace Business.Concrete
{
    public class UsersManager : IUsersService
    { 

        private readonly IUsersDal _usersDal;
        private readonly UsersBusinessRules _usersBusinessRules;
        private readonly IMapper _mapper;

        public UsersManager(IUsersDal usersDal, UsersBusinessRules usersBusinessRules, IMapper mapper)
        {
            _usersDal = usersDal;
            _usersBusinessRules = usersBusinessRules;
            _mapper = mapper;
        }

        public AddUsersResponse Add(AddUsersRequest request)
        {
            ValidationTool.Validate(new AddUsersRequestValidator(), request);
            _usersBusinessRules.CheckIfUserNameExists(request.FirstName, request.LastName);
            var usersToAdd = _mapper.Map<Users>(request);
            Users addedUsers = _usersDal.Add(usersToAdd);
            var response = _mapper.Map<AddUsersResponse>(addedUsers);
            return response;
        }

        public DeleteUsersResponse Delete(DeleteUsersRequest request)
        {
            Users? usersToDelete = _usersDal.Get(predicate:users=>users.Id == request.Id);
            _usersBusinessRules.CheckIfUserExists(usersToDelete);
            Users deletedUsers = _usersDal.Delete(usersToDelete!);
            var response = _mapper.Map<DeleteUsersResponse>(deletedUsers);
            return response;
        }

        public GetUsersListResponse GetList(GetUsersListRequest request)
        {
            IList<Users> usersList = _usersDal.GetList();
            GetUsersListResponse response = _mapper.Map<GetUsersListResponse>(usersList);
            return response;                
                }

        public UpdateUserResponse Update(UpdateUsersRequest request)
        {
            Users? userToUpdate = _usersDal.Get(predicate: user => user.Id == request.Id);
            _usersBusinessRules.CheckIfUserExists(userToUpdate);
            userToUpdate = _mapper.Map(request, userToUpdate);
            Users updatedUsers = _usersDal.Update(userToUpdate!);
            var response = _mapper.Map<UpdateUserResponse>(updatedUsers);
            return response;
        }
    }
}
