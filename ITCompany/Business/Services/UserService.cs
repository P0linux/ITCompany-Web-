using AutoMapper;
using ITCompany.Business.Interfaces;
using ITCompany.Data.Repository;
using ITCompany.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public SignInResult Login(UserLoginModel userLoginModel)
        {
            var result = unit.SignInManager.PasswordSignInAsync
        }

        public IdentityResult Register(UserRegisterModel userRegisterModel)
        {
            throw new NotImplementedException();
        }

        public void SignOut()
        {
            throw new NotImplementedException();
        }
    }
}
