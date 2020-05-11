using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiApp.Data.RepositoryInterfaces;

namespace WebApiApp.Data
{
    public interface IUnitOfWork
    {
        IDepartmentRepository DepartmentRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        IProblemRepository ProblemRepository { get; }
        IDepartmentEmployeeRepository DepartmentEmployeeRepository { get; }
        void Commit();
    }
}
