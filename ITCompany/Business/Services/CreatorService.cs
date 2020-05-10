using AutoMapper;
using ITCompany.Business.Interfaces;
using ITCompany.Data.Entities;
using ITCompany.Data.Repository;
using ITCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCompany.Business.Services
{
    public class CreatorService: ICreatorService
    {
        IUnitOfWork unitOfWork;
        IMapper mapper;
        IDepartmentService departmentService;
        IEmployeeService employeeService;
        public CreatorService(IUnitOfWork unitOfWork, IMapper mapper, IDepartmentService departmentService, IEmployeeService employeeService)
        {
            this.departmentService = departmentService;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.employeeService = employeeService;
        }

        public void CreateDepartment(Department department)
        {
            var dep = mapper.Map<DepartmentEntity>(department);
            unitOfWork.DepartmentRepository.Insert(dep);
            unitOfWork.Commit();
        }

        public void CreateEmployee(EmployeeParameters parameters)
        {
            Employee emp = new Employee(parameters.Name, parameters.DateOfBirth);
            var employee = mapper.Map<EmployeeEntity>(emp);
            unitOfWork.EmployeeRepository.Insert(employee);
            unitOfWork.Commit();
            CreateDepartmentEmployee(parameters);

        }

        private void CreateDepartmentEmployee(EmployeeParameters parameters)
        {
            Employee emp = employeeService.FindByName(parameters.Name).First();
            Department dep = departmentService.FindByName(parameters.DepartmentName).First();
            DepartmentEmployee departmentEmployee = new DepartmentEmployee(dep.Id, emp.Id);
            var depemp = mapper.Map<DepartmentEmployeeEntity>(departmentEmployee);
            unitOfWork.DepartmentEmployeeRepository.Insert(depemp);
            unitOfWork.Commit();
        }

        public void CreateProblem(Problem problem, string employeeName)
        {
            var employees = unitOfWork.EmployeeRepository.GetAll();
            problem.EmployeeId = employees.Where(e => e.Name.Equals(employeeName)).First().Id;
            var pr = mapper.Map<ProblemEntity>(problem);
            unitOfWork.ProblemRepository.Insert(pr);
            unitOfWork.Commit();
        }
    }
}
