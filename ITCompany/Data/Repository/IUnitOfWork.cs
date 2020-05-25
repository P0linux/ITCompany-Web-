using ITCompany.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCompany.Data.Repository
{
    public interface IUnitOfWork
    {
        SignInManager<User> SignInManager { get; }
        UserManager<User> UserManager { get; }
        DepartmentRepository DepartmentRepository { get; }
        EmployeeRepository EmployeeRepository { get; }
        ProblemRepository ProblemRepository { get; }
        DepartmentEmployeeRepository DepartmentEmployeeRepository { get; }
        void Commit();
    }
}
