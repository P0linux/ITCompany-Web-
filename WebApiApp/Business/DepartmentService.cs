using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiApp.Business.Interfaces;
using WebApiApp.Data;
using WebApiApp.Data.Entities;
using WebApiApp.Models;

namespace WebApiApp.Business
{
    public class DepartmentService:IDepartmentService
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

        public IEnumerable<DepartmentModel> GetAll()
        {
            var departments = unitOfWork.DepartmentRepository.GetAll();
            return mapper.Map<IEnumerable<DepartmentModel>>(departments);
        }

        public void DeleteById(int Id)
        {
            unitOfWork.DepartmentRepository.DeleteById(Id);
            unitOfWork.Commit();
        }

        public DepartmentModel GetById(int Id)
        {
            var department = unitOfWork.DepartmentRepository.GetById(Id);
            return mapper.Map<DepartmentModel>(department);
        }

        public void Update(DepartmentModel department)
        {
            var dep = mapper.Map<Department>(department);
            unitOfWork.DepartmentRepository.Update(dep);
            unitOfWork.Commit();
        }

        public void Create(DepartmentModel department)
        {
            var dep = mapper.Map<Department>(department);
            unitOfWork.DepartmentRepository.Insert(dep);
            unitOfWork.Commit();
        }

        public IEnumerable<DepartmentModel> FindByName(string name)
        {
            var departments = unitOfWork.DepartmentRepository.GetAll().ToList();
            IEnumerable<DepartmentModel> dep = mapper.Map<IEnumerable<DepartmentModel>>(departments);
            return dep.Where(d => d.Name.Equals(name));
        }

        public IEnumerable<DepartmentModel> FindByProblem(string problemName)
        {
            var departmentEmployees = unitOfWork.DepartmentEmployeeRepository.GetAll().ToList();
            var employeesByProblem = employeeService.FindByProblem(problemName);
            var employeesByProblemId = employeesByProblem.Select(e => e.Id).ToList();
            var depId = departmentEmployees.Where(d => employeesByProblemId.Contains(d.EmployeeId)).Select(d => d.DepartmentId).Distinct();
            var dep = depId.Select(d => unitOfWork.DepartmentRepository.GetById(d)).ToList();
            return mapper.Map<List<DepartmentModel>>(dep);
        }

        public IEnumerable<DepartmentModel> FindByEmployee(string employeeName)
        {
            var departmentEmployees = unitOfWork.DepartmentEmployeeRepository.GetAll();
            var department = departmentEmployees.Where(de => de.Employee.Name == employeeName).Select(de => de.Department);
            return mapper.Map<List<DepartmentModel>>(department);
            //var employeeByName = unitOfWork.EmployeeRepository.GetAll().Where(e => e.Name == employeeName).First();
            //var departments = unitOfWork.DepartmentRepository.GetAll();
            //var depId = departmentEmployees.Where(d => d.EmployeeId == employeeByName.Id).Select(d => d.DepartmentId).Distinct();
            //return mapper.Map<List<Department>>(departments.Where(d => depId.Contains(d.Id)));
        }
    }
}

