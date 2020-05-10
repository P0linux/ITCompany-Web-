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
    public class DepartmentService: IDepartmentService
    {
        IUnitOfWork unitOfWork;
        IEmployeeService employeeService;
        IMapper mapper;
        public DepartmentService(IUnitOfWork unitOfWork, IEmployeeService employeeService, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.employeeService = employeeService;
            this.mapper = mapper;
        }

        public IEnumerable<Department> FindByName(string name)
        {
            var departments = unitOfWork.DepartmentRepository.GetAll().ToList();
            IEnumerable<Department> dep = mapper.Map<IEnumerable<Department>>(departments);
            return dep.Where(d => d.Name.Equals(name));
        }

        public IEnumerable<Department> FindByProblem(string problemName)
        {
            var departmentEmployees = unitOfWork.DepartmentEmployeeRepository.GetAll().ToList();
            var employeesByProblem = employeeService.FindByProblem(problemName);
            var employeesByProblemId = employeesByProblem.Select(e => e.Id).ToList();
            var depId = departmentEmployees.Where(d => employeesByProblemId.Contains(d.EmployeeId)).Select(d => d.DepartmentId).Distinct();
            var dep = depId.Select(d => unitOfWork.DepartmentRepository.GetById(d)).ToList();
            return mapper.Map<List<Department>>(dep);
        }

        public IEnumerable<Department> FindByEmployee(string employeeName)
        {
            var departmentEmployees = unitOfWork.DepartmentEmployeeRepository.GetAll();
            var employeeByName = unitOfWork.EmployeeRepository.GetAll().Where(e => e.Name == employeeName).First();
            var departments = unitOfWork.DepartmentRepository.GetAll();
            var depId = departmentEmployees.Where(d => d.EmployeeId == employeeByName.Id).Select(d => d.DepartmentId).Distinct();
            return mapper.Map<List<Department>>(departments.Where(d => depId.Contains(d.Id)));
        }
    }
}
