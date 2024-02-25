using Core.CrossCuttingConcerns.Exceptions;
using Core.Entities;
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
        private readonly IUserDal _userDal;

        public UsersBusinessRules(IUserDal usersDal)
        {
            _userDal = usersDal;
        }

       

        public void CheckIfUserExists(Userr? users)
        {
            if (users is null)
                throw new NotFoundException("User not found.");
        }
    }
}
