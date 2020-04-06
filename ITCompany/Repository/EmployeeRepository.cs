using ITCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCompany.Repository
{
    public class EmployeeRepository : IRepository<Employee>
    {
        ICollection<Employee> employees;
        public EmployeeRepository()
        {
            this.employees = Data.employees;
        }
        public void DeleteById(int Id)
        {
            Employee employee = employees.FirstOrDefault(e => e.Id == Id);
            employees.Remove(employee);
        }

        public IEnumerable<Employee> GetAll()
        {
            return employees;
        }

        public Employee GetById(int Id)
        {
            return employees.FirstOrDefault(e => e.Id == Id);
        }

        public void Insert(Employee entity)
        {
            employees.Add(entity);
        }

        public void Update(Employee entity)
        {
            Employee employee = employees.FirstOrDefault(e => e.Id == entity.Id);
            employees.Remove(employee);
            employees.Add(entity);
        }
    }
}
