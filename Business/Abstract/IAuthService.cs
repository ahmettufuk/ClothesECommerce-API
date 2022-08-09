using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegister userForRegisterDto, string password);
        IDataResult<User> Login(UserForLogin userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
