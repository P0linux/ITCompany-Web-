using ITCompany.Models;
using ITCompany.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCompany.Services
{
    public class DepartmentService
    {
        UnitOfWork unitOfWork;
        EmployeeService employeeService;
        public DepartmentService(UnitOfWork unitOfWork, EmployeeService employeeService)
        {
            this.unitOfWork = unitOfWork;
            this.employeeService = employeeService;
        }

        public IEnumerable<Department> FindByName(string name)
        {
            var departments = unitOfWork.DepartmentRepository.GetAll();
            return departments.Where(d => d.Name.Equals(name));
        }

        public IEnumerable<Department> FindByProblem(string problemName)
        {
            var departmentEmployees = unitOfWork.DepartmentEmployeeRepository.GetAll();
            var employeesByProblem = employeeService.FindByProblem(problemName);
            return departmentEmployees.Where(d => employeesByProblem.Contains(d.Employee)).Select(d => d.Department);            
        }

        public IEnumerable<Department> FindByEmployee(string employeeName)
        {
            var departmentEmployees = unitOfWork.DepartmentEmployeeRepository.GetAll();
            return departmentEmployees.Where(d => d.Employee.Name.Equals(employeeName)).Select(d => d.Department);
        }
    }
}
