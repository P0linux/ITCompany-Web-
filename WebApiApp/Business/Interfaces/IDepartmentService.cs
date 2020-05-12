using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiApp.Models;

namespace WebApiApp.Business.Interfaces
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentModel> GetAll();
        DepartmentModel GetById(int Id);
        void DeleteById(int Id);
        void Create(DepartmentModel department);
        void Update(DepartmentModel department);
        IEnumerable<DepartmentModel> FindByName(string name);
        IEnumerable<DepartmentModel> FindByProblem(string problemName);
        IEnumerable<DepartmentModel> FindByEmployee(string employeeName);
    }
}
