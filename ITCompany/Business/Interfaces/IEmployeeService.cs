using ITCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCompany.Business.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> FindByName(string name);
        IEnumerable<Employee> FindByDate(string date);
        IEnumerable<Employee> FindByProblem(string name);
        IEnumerable<Employee> FindByDepartmentName(string name);

    }
}
