using AutoMapper;
using ITCompany.Business.Interfaces;
using ITCompany.Data.Repository;
using ITCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCompany.Business.Services
{
    public class EmployeeService: IEmployeeService
    {
        IUnitOfWork unitOfWork;
        IMapper mapper;

      
        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }


        public IEnumerable<Employee> FindByName(string name)
        {
            var employees = unitOfWork.EmployeeRepository.GetAll();
            IEnumerable<Employee> emp = mapper.Map<IEnumerable<Employee>>(employees);
            return emp.Where(e => e.Name.Equals(name));
        }

        public IEnumerable<Employee> FindByDate(string date)
        {
            var employees = unitOfWork.EmployeeRepository.GetAll();
            IEnumerable<Employee> emp = mapper.Map<IEnumerable<Employee>>(employees);
            return emp.Where(e => e.DateOfBirth == date);
        }

        public IEnumerable<Employee> FindByProblem(string problemName)
        {
            var employees = unitOfWork.EmployeeRepository.GetAll();
            IEnumerable<Employee> emp = mapper.Map<IEnumerable<Employee>>(employees);
            return emp.SelectMany(e => e.Problems, (employee, problem) => new { employee, problem})
                .Where(e => e.problem.Name == problemName).Select(e => e.employee);
        }

        public IEnumerable<Employee> FindByDepartmentName(string name)
        {
            var departmentEmployees = unitOfWork.DepartmentEmployeeRepository.GetAll();
            IEnumerable<DepartmentEmployee> emp = mapper.Map<IEnumerable<DepartmentEmployee>>(departmentEmployees);
            return emp.Where(d => d.Department.Name.Equals(name)).Select(d => d.Employee);
        }
    }
}
