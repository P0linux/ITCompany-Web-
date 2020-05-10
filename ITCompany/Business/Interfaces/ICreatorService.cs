using ITCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCompany.Business.Interfaces
{
    public interface ICreatorService
    {
        void CreateDepartment(Department department);
        void CreateEmployee(EmployeeParameters parameters);
        void CreateProblem(Problem problem, string employeeName);
    }
}
