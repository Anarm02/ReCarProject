using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;
        public AuthManager(ITokenHelper tokenHelper, IUserService userService)
        {
            _tokenHelper = tokenHelper;
            _userService = userService;
        }
        public IDataResult<AccesToken> CreateAccessToken(User user)
        {
            var claims=_userService.GetClaims(user).Data;
            var accessToken = _tokenHelper.CreateToken(user,claims);
            return new SuccessDataResult<AccesToken>(accessToken);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByEmail(userForLoginDto.Email);
           
            if (userToCheck.Data == null)
            {
                return new ErrorDataResult<User>(Messages.userNotExist);
            }
            else if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            
                return new SuccessDataResult<User>(userToCheck.Data,Messages.SuccessfullLogin);
            
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordSalt, passwordHash;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password,out passwordHash, out passwordSalt);
            var user = new User{
            Email = userForRegisterDto.Email,
            FirstName = userForRegisterDto.FirstName,
            LastName = userForRegisterDto.LastName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Status=true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user,Messages.UserRegistered);

        }

        public IResult UserExist(string email)
        {
            var userToCheck= _userService.GetByEmail(email);    
            if (userToCheck.Data != null)
            {
                return new ErrorResult(Messages.UserAlreadyExist);
            }
            return new SuccessResult(Messages.userNotExist);
        }
    }
}
