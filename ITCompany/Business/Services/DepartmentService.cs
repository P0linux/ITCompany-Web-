using AutoMapper;
using ITCompany.Data.Repository;
using ITCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCompany.Business.Services
{
    public class DepartmentService
    {
        UnitOfWork unitOfWork;
        EmployeeService employeeService;
        IMapper mapper;
        public DepartmentService(UnitOfWork unitOfWork, EmployeeService employeeService, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.employeeService = employeeService;
            this.mapper = mapper;
        }

        public IEnumerable<Department> FindByName(string name)
        {
            var departments = unitOfWork.DepartmentRepository.GetAll();
            IEnumerable<Department> dep = mapper.Map<IEnumerable<Department>>(departments);
            return dep.Where(d => d.Name.Equals(name));
        }

        public IEnumerable<Department> FindByProblem(string problemName)
        {
            var departmentEmployees = unitOfWork.DepartmentEmployeeRepository.GetAll();
            var employeesByProblem = employeeService.FindByProblem(problemName);
            IEnumerable<DepartmentEmployee> depemp = mapper.Map<IEnumerable<DepartmentEmployee>>(departmentEmployees);
            return depemp.Where(d => employeesByProblem.Contains(d.Employee)).Select(d => d.Department);            
        }

        public IEnumerable<Department> FindByEmployee(string employeeName)
        {
            var departmentEmployees = unitOfWork.DepartmentEmployeeRepository.GetAll();
            IEnumerable<DepartmentEmployee> depemp = mapper.Map<IEnumerable<DepartmentEmployee>>(departmentEmployees); 
            return depemp.Where(d => d.Employee.Name.Equals(employeeName)).Select(d => d.Department);
        }
    }
}
