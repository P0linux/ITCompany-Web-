using ITCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCompany.Repository
{
    public class DepartmentRepository : IRepository<Department>
    {
        ICollection<Department> departments;
        public DepartmentRepository()
        {
            this.departments = Data.departments;
        }
        public void DeleteById(int Id)
        {
            Department department = departments.FirstOrDefault(e => e.Id == Id);
            departments.Remove(department);
        }

        public IEnumerable<Department> GetAll()
        {
            return departments;
        }

        public Department GetById(int Id)
        {
            return departments.FirstOrDefault(e => e.Id == Id);
        }

        public void Insert(Department entity)
        {
            departments.Add(entity);
        }

        public void Update(Department entity)
        {
            Department department = departments.FirstOrDefault(e => e.Id == entity.Id);
            departments.Remove(department);
            departments.Add(entity);
        }
    }
}
