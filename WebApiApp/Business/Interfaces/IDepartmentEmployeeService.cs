using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiApp.Models;

namespace WebApiApp.Business.Interfaces
{
    public interface IDepartmentEmployeeService
    {
        IEnumerable<DepartmentEmployeeModel> GetAll();
        DepartmentEmployeeModel GetById(int Id);
        void DeleteById(int Id);
        void Create(DepartmentEmployeeModel departmentEmp);
        void Update(DepartmentEmployeeModel departmentEmp);
    }
}
