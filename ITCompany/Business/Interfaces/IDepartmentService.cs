using ITCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCompany.Business.Interfaces
{
    public interface IDepartmentService
    {
        IEnumerable<Department> FindByName(string name);
        IEnumerable<Department> FindByProblem(string name);
        IEnumerable<Department> FindByEmployee(string name);
    }
}
