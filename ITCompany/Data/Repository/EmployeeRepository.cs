using ITCompany.Data.Entities;
using ITCompany.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCompany.Data.Repository
{
    public class EmployeeRepository : IRepository<EmployeeEntity>
    {
        DbSet<EmployeeEntity> employees;
        public EmployeeRepository(ApplicationContext context)
        {
            employees = context.Set<EmployeeEntity>();
        }
        public void DeleteById(int Id)
        {
            EmployeeEntity employee = employees.Find(Id);
            employees.Remove(employee);
        }

        public IEnumerable<EmployeeEntity> GetAll()
        {
            return employees;
        }

        public EmployeeEntity GetById(int Id)
        {
            return employees.Find(Id);
        }

        public void Insert(EmployeeEntity entity)
        {
            employees.Add(entity);
        }

        public void Update(EmployeeEntity entity)
        {
            employees.Update(entity);
        }
    }
}
