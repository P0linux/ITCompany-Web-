using ITCompany.Models;
using ITCompany.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCompany.Services
{
    public class EmployeeService
    {
        UnitOfWork unitOfWork;
        public EmployeeService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Employee> FindByName(string name)
        {
            var employees = unitOfWork.EmployeeRepository.GetAll();
            return employees.Where(e => e.Name.Equals(name));
        }

        public IEnumerable<Employee> FindByDate(DateTime date)
        {
            var employees = unitOfWork.EmployeeRepository.GetAll();
            return employees.Where(e => e.DateOfBirth == date);
        }

        public IEnumerable<Employee> FindByProblem(string problemName)
        {
            var employees = unitOfWork.EmployeeRepository.GetAll();
            return employees.SelectMany(e => e.Problems, (employee, problem) => new { employee, problem})
                .Where(e => e.problem.Name == problemName).Select(e => e.employee);
        }

        public IEnumerable<Employee> FindByDepartmentName(string name)
        {
            var departmentEmployees = unitOfWork.DepartmentEmployeeRepository.GetAll();
            return departmentEmployees.Where(d => d.Department.Name.Equals(name)).Select(d => d.Employee);
        }
    }
}
