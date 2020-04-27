using ITCompany.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCompany.Data.Repository
{
    public class DepartmentRepository : IRepository<DepartmentEntity>
    {
        DbSet<DepartmentEntity> departments;
        public DepartmentRepository(ApplicationContext context)
        {
            departments = context.Set<DepartmentEntity>();
        }
        public void DeleteById(int Id)
        {
            DepartmentEntity department = departments.Find(Id);
            departments.Remove(department);
        }

        public IEnumerable<DepartmentEntity> GetAll()
        {
            return departments;
        }

        public DepartmentEntity GetById(int Id)
        {
            return departments.Find(Id);
        }

        public void Insert(DepartmentEntity entity)
        {
            departments.Add(entity);
        }

        public void Update(DepartmentEntity entity)
        {
            departments.Update(entity);
        }
    }
}
