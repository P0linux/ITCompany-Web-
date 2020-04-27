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
        public CreatorService(IUnitOfWork unitOfWork, IMapper mapper, IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
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
            emp.Problems = CreateListOfProblems(parameters).ToList();
            var employee = mapper.Map<EmployeeEntity>(emp);
            unitOfWork.EmployeeRepository.Insert(employee);
            CreateDepartmentEmployee(parameters, emp);
            unitOfWork.Commit();
        }

        private IEnumerable<Problem> CreateListOfProblems(EmployeeParameters parameters)
        {
            var problems = unitOfWork.ProblemRepository.GetAll();
            IEnumerable<Problem> prob = mapper.Map<IEnumerable<Problem>>(problems);
            return prob.Where(p => parameters.Problems.Contains(p.Name)).ToList(); 
        }

        private void CreateDepartmentEmployee(EmployeeParameters parameters, Employee emp)
        {
            //var departments = unitOfWork.DepartmentRepository.GetAll();
            //IEnumerable<Department> department = mapper.Map<IEnumerable<Department>>(departments);
            //Department dep = department.FirstOrDefault(d => d.Name.Equals(parameters.DepartmentName));
            Department dep = departmentService.FindByName(parameters.DepartmentName).First();
            DepartmentEmployee departmentEmployee = new DepartmentEmployee(dep.Id, emp.Id);
            var depemp = mapper.Map<DepartmentEmployeeEntity>(departmentEmployee);
            unitOfWork.DepartmentEmployeeRepository.Insert(depemp);
        }

        public void CreateProblem(Problem problem)
        {
            var pr = mapper.Map<ProblemEntity>(problem);
            unitOfWork.ProblemRepository.Insert(pr);
            unitOfWork.Commit();
        }
    }
}
