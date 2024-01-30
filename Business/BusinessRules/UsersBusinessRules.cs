using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class UsersBusinessRules
    {
        private readonly IUsersDal _usersDal;

        public UsersBusinessRules(IUsersDal usersDal)
        {
            _usersDal = usersDal;
        }

        public void CheckIfUserNameExists(string firstName,string lastName)
        {
            bool isNameExists = _usersDal.Get(u => u.FirstName == firstName && u.LastName==lastName) != null;
            if (isNameExists)
                throw new BusinessException("Users  already exists.");
        }

        public void CheckIfUserExists(Users? users)
        {
            if (users is null)
                throw new NotFoundException("User not found.");
        }
    }
}
