using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCompany.Data.Repository
{
    public interface IUnitOfWork
    {
        DepartmentRepository DepartmentRepository { get; }
        EmployeeRepository EmployeeRepository { get; }
        ProblemRepository ProblemRepository { get; }
        DepartmentEmployeeRepository DepartmentEmployeeRepository { get; }
        void Commit();
    }
}
