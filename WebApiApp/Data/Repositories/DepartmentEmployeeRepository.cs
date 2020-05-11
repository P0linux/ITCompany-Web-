using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiApp.Data.Entities;
using WebApiApp.Data.RepositoryInterfaces;

namespace WebApiApp.Data.Repositories
{
    public class DepartmentEmployeeRepository:IDepartmentEmployeeRepository
    {
        DbSet<DepartmentEmployee> departmentEmployees;
        public DepartmentEmployeeRepository(ApplicationContext context)
        {
            departmentEmployees = context.Set<DepartmentEmployee>();
        }
        public void DeleteById(int Id)
        {
            DepartmentEmployee employee = departmentEmployees.Find(Id);
            departmentEmployees.Remove(employee);
        }

        public IEnumerable<DepartmentEmployee> GetAll()
        {
            //TEST LINE (DELETE OR REDO)
            return departmentEmployees.Include(de => de.Department).Include(de => de.Employee);
        }

        public DepartmentEmployee GetById(int Id)
        {
            return departmentEmployees.Find(Id);
        }

        public void Insert(DepartmentEmployee entity)
        {
            departmentEmployees.Add(entity);
        }

        public void Update(DepartmentEmployee entity)
        {
            departmentEmployees.Update(entity);
        }
    }
}

