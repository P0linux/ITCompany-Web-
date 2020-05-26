using AutoMapper;
using ITCompany.Business.Interfaces;
using ITCompany.Data.Entities;
using ITCompany.Data.Repository;
using ITCompany.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ITCompany.Business.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork unit;
        IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            unit = unitOfWork;
            _mapper = mapper;
        }
        public async Task<SignInResult> Login(UserLoginModel userLoginModel)
        {
            var res = await unit.SignInManager.PasswordSignInAsync(userLoginModel.Email, userLoginModel.Password, userLoginModel.RememberMe, false);
            return res;
        }

        public async Task<IdentityResult> Register(UserRegisterModel userRegisterModel)
        {
            var user = _mapper.Map<User>(userRegisterModel);
            var res = await unit.UserManager.CreateAsync(user, userRegisterModel.Password);
            return res;
        }

        public async Task SignOut()
        {
            await unit.SignInManager.SignOutAsync();
        }
    }
}
