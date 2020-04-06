using ITCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCompany.Repository
{
    public class DepartmentEmployeeRepository : IRepository<DepartmentEmployee>
    {
        ICollection<DepartmentEmployee> departmentEmployees;
        public DepartmentEmployeeRepository()
        {
            this.departmentEmployees = Data.departmentEmployees;
        }
        public void DeleteById(int Id)
        {
            DepartmentEmployee employee = departmentEmployees.FirstOrDefault(e => e.Id == Id);
            departmentEmployees.Remove(employee);
        }

        public IEnumerable<DepartmentEmployee> GetAll()
        {
            return departmentEmployees;
        }

        public DepartmentEmployee GetById(int Id)
        {
            return departmentEmployees.FirstOrDefault(d => d.Id == Id);
        }

        public void Insert(DepartmentEmployee entity)
        {
            departmentEmployees.Add(entity);
        }

        public void Update(DepartmentEmployee entity)
        {
            DepartmentEmployee employee = departmentEmployees.FirstOrDefault(e => e.Id == entity.Id);
            departmentEmployees.Remove(employee);
            departmentEmployees.Add(entity);
        }
    }
}
