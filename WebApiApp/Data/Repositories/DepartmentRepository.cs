using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiApp.Data.Entities;
using WebApiApp.Data.RepositoryInterfaces;

namespace WebApiApp.Data.Repositories
{
    public class DepartmentRepository:IDepartmentRepository
    {
        DbSet<Department> departments;
        public DepartmentRepository(ApplicationContext context)
        {
            departments = context.Set<Department>();
        }
        public void DeleteById(int Id)
        {
            Department department = departments.Find(Id);
            departments.Remove(department);
        }

        public IEnumerable<Department> GetAll()
        {
            return departments;
        }

        public Department GetById(int Id)
        {
            return departments.Find(Id);
        }

        public void Insert(Department entity)
        {
            departments.Add(entity);
        }

        public void Update(Department entity)
        {
            departments.Update(entity);
        }
    }
}
