using ITCompany.Models;
using ITCompany.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCompany.Services
{
    public class CreatorService
    {
        UnitOfWork unitOfWork;
        public CreatorService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void CreateDepartment(Department department)
        {
            unitOfWork.DepartmentRepository.Insert(department);
        }

        public void CreateEmployee(EmployeeParameters parameters)
        {
            Employee emp = new Employee(parameters.Name, parameters.DateOfBirth);
            var problems = unitOfWork.ProblemRepository.GetAll();
            emp.Problems = problems.Where(p => parameters.Problems.Contains(p.Name)).ToList();
            unitOfWork.EmployeeRepository.Insert(emp);
            var departments = unitOfWork.DepartmentRepository.GetAll();
            Department dep = departments.FirstOrDefault(d => d.Name.Equals(parameters.DepartmentName));
            unitOfWork.DepartmentEmployeeRepository.Insert(new DepartmentEmployee(dep.Id, emp.Id, dep, emp));
        }

        public void CreateProblem(Problem problem)
        {
            unitOfWork.ProblemRepository.Insert(problem);
        }
    }
}
