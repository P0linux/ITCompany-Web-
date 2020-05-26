using ITCompany.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCompany.Business.Interfaces
{
    interface IUserService
    {
        Task<IdentityResult> Register(UserRegisterModel userRegisterModel);
        Task<SignInResult> Login(UserLoginModel userLoginModel);
        Task SignOut();
    }
}
