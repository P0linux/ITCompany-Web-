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
    public class EmployeeService: IEmployeeService
    {
        IUnitOfWork unitOfWork;
        IMapper mapper;


        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<EmployeeModel> GetAll()
        {
            var employees = unitOfWork.EmployeeRepository.GetAll();
            return mapper.Map<IEnumerable<EmployeeModel>>(employees);
        }

        public void DeleteById(int Id)
        {
            unitOfWork.EmployeeRepository.DeleteById(Id);
            unitOfWork.Commit();
        }

        public EmployeeModel GetById(int Id)
        {
            var employee = unitOfWork.EmployeeRepository.GetById(Id);
            return mapper.Map<EmployeeModel>(employee);
        }

        public void Update(EmployeeModel employee)
        {
            var emp = mapper.Map<Employee>(employee);
            unitOfWork.EmployeeRepository.Update(emp);
            unitOfWork.Commit();
        }

        public void Create(EmployeeModel employee)
        {
            var emp = mapper.Map<Employee>(employee);
            unitOfWork.EmployeeRepository.Insert(emp);
            unitOfWork.Commit();
        }

        public IEnumerable<EmployeeModel> FindByName(string name)
        {
            var employees = unitOfWork.EmployeeRepository.GetAll();
            IEnumerable<EmployeeModel> emp = mapper.Map<IEnumerable<EmployeeModel>>(employees);
            return emp.Where(e => e.Name.Equals(name));
        }

        public IEnumerable<EmployeeModel> FindByDate(string date)
        {
            var employees = unitOfWork.EmployeeRepository.GetAll();
            IEnumerable<EmployeeModel> emp = mapper.Map<IEnumerable<EmployeeModel>>(employees);
            return emp.Where(e => e.DateOfBirth == date);
        }

        public IEnumerable<EmployeeModel> FindByProblem(string problemName)
        {
            var employees = unitOfWork.EmployeeRepository.GetAll().ToList();
            var problemsByEmployeeId = unitOfWork.ProblemRepository.GetAll().Select(p => p.EmployeeId).ToList();
            IEnumerable<EmployeeModel> emp = mapper.Map<IEnumerable<EmployeeModel>>(employees);
            return emp.Where(e => problemsByEmployeeId.Contains(e.Id)).ToList();
        }

        public IEnumerable<EmployeeModel> FindByDepartmentName(string name)
        {
            var departmentEmployees = unitOfWork.DepartmentEmployeeRepository.GetAll().ToList();
            var departments = unitOfWork.DepartmentRepository.GetAll().ToList();
            var employees = unitOfWork.EmployeeRepository.GetAll().ToList();
            var depByName = departments.Where(d => d.Name == name).First();
            var empId = departmentEmployees.Where(d => d.DepartmentId == depByName.Id).Select(d => d.EmployeeId);
            return mapper.Map<List<EmployeeModel>>(empId.Select(e => unitOfWork.EmployeeRepository.GetById(e)));
        }
    }
}

