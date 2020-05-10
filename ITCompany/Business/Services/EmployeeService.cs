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
            var employees = unitOfWork.EmployeeRepository.GetAll().ToList();
            var problemsByEmployeeId = unitOfWork.ProblemRepository.GetAll().Select(p => p.EmployeeId).ToList();
            IEnumerable<Employee> emp = mapper.Map<IEnumerable<Employee>>(employees);
            return emp.Where(e => problemsByEmployeeId.Contains(e.Id)).ToList();
        }

        public IEnumerable<Employee> FindByDepartmentName(string name)
        {
            var departmentEmployees = unitOfWork.DepartmentEmployeeRepository.GetAll().ToList();
            var departments = unitOfWork.DepartmentRepository.GetAll().ToList();
            var employees = unitOfWork.EmployeeRepository.GetAll().ToList();
            var depByName = departments.Where(d => d.Name == name).First();
            var empId = departmentEmployees.Where(d => d.DepartmentId == depByName.Id).Select(d => d.EmployeeId);
            return mapper.Map<List<Employee>>(empId.Select(e => unitOfWork.EmployeeRepository.GetById(e)));
        }
    }
}
