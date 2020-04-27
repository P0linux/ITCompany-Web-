using ITCompany.Data.Entities;
using ITCompany.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCompany.Data.Repository
{
    public class DepartmentEmployeeRepository : IRepository<DepartmentEmployeeEntity>
    {
        DbSet<DepartmentEmployeeEntity> departmentEmployees;
        public DepartmentEmployeeRepository(ApplicationContext context)
        {
            departmentEmployees = context.Set<DepartmentEmployeeEntity>();
        }
        public void DeleteById(int Id)
        {
            DepartmentEmployeeEntity employee = departmentEmployees.Find(Id);
            departmentEmployees.Remove(employee);
        }

        public IEnumerable<DepartmentEmployeeEntity> GetAll()
        {
            return departmentEmployees;
        }

        public DepartmentEmployeeEntity GetById(int Id)
        {
            return departmentEmployees.Find(Id);
        }

        public void Insert(DepartmentEmployeeEntity entity)
        {
            departmentEmployees.Add(entity);
        }

        public void Update(DepartmentEmployeeEntity entity)
        {
            departmentEmployees.Update(entity);
        }
    }
}
