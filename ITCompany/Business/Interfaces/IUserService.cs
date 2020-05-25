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
        IdentityResult Register(UserRegisterModel userRegisterModel);
        SignInResult Login(UserLoginModel userLoginModel);
        void SignOut();
    }
}
