using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiApp.Data.Entities;
using WebApiApp.Models;

namespace WebApiApp.Business
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeModel> GetAll();
        EmployeeModel GetById(int Id);
        void DeleteById(int Id);
        void Create(EmployeeModel employee);
        void Update(EmployeeModel employee);
        IEnumerable<EmployeeModel> FindByName(string name);
        IEnumerable<EmployeeModel> FindByDate(string date);
        IEnumerable<EmployeeModel> FindByProblem(string name);
        IEnumerable<EmployeeModel> FindByDepartmentName(string name);
    }
}
