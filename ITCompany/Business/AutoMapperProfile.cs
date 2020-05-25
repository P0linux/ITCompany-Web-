using AutoMapper;
using ITCompany.Data.Entities;
using ITCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCompany.Business
{
    public class AutoMapperProfile: Profile 
    {
        public AutoMapperProfile()
        {
            CreateMap<Department, DepartmentEntity>().ReverseMap();
            CreateMap<Employee, EmployeeEntity>().ReverseMap();
            CreateMap<DepartmentEmployee, DepartmentEmployeeEntity>().ReverseMap();
            CreateMap<Problem, ProblemEntity>().ReverseMap();
            CreateMap<UserRegisterModel, User>();
        } 
    }
}
