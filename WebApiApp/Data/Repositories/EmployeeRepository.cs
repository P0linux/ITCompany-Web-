using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiApp.Data.Entities;
using WebApiApp.Data.RepositoryInterfaces;

namespace WebApiApp.Data.Repositories
{
    public class EmployeeRepository:IEmployeeRepository
    {
        DbSet<Employee> employees;
        public EmployeeRepository(ApplicationContext context)
        {
            employees = context.Set<Employee>();
        }
        public void DeleteById(int Id)
        {
            Employee employee = employees.Find(Id);
            employees.Remove(employee);
        }

        public IEnumerable<Employee> GetAll()
        {
            return employees;
        }

        public Employee GetById(int Id)
        {
            return employees.Find(Id);
        }

        public void Insert(Employee entity)
        {
            employees.Add(entity);
        }

        public void Update(Employee entity)
        {
            employees.Update(entity);
        }
    }
}
