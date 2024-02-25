using Business.Abstract;
using Business.Requests.User;
using Core.Entities;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserRoleDal _userRoleDal;
        public UserManager(IUserDal userDal, ITokenHelper tokenHelper,IUserRoleDal userRoleDal)
        {
            _userDal = userDal;
            _tokenHelper = tokenHelper;
            _userRoleDal = userRoleDal;
        }

        public AccessToken Login(LoginRequest request)
        {
            Userr? user = _userDal.Get(i => i.Email == request.Email);
            UserRole? userRole = _userRoleDal.Get(i => i.Id == request.UserRoleId);
            bool isPasswordCorrect = HashingHelper.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt);
            if(isPasswordCorrect)
            {
               throw new Exception("Şifre Yanlış");
            }
            return _tokenHelper.CreateToken(user,userRole);
        }

        public void Register(RegisterRequest request)
        {
            byte[] passwordSalt, passwordHash;
            HashingHelper.CreatePasswordHash(request.Password,out passwordHash, out passwordSalt);

            //TODO: Auto-Mapping

            Userr user = new Userr();
            user.Email = request.Email;
            user.Approved = false;
            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;
            _userDal.Add(user);
        }
    }
}
