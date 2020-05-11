using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiApp.Data.Entities;
using WebApiApp.Models;

namespace WebApiApp
{
    public class AutoMapperProfile:Profile 
    {
        public AutoMapperProfile()
        {
            CreateMap<DepartmentModel, Department>().ReverseMap();
            CreateMap<EmployeeModel, Employee>().ReverseMap();
            CreateMap<DepartmentEmployeeModel, DepartmentEmployee>().ReverseMap();
            CreateMap<ProblemModel, Problem>().ReverseMap();
        }
    }
}
