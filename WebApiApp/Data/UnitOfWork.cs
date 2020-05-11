using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiApp.Data.Repositories;
using WebApiApp.Data.RepositoryInterfaces;

namespace WebApiApp.Data
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationContext context;
        private IDepartmentRepository departmentRepository;
        private IEmployeeRepository employeeRepository;
        private IProblemRepository problemRepository;
        private IDepartmentEmployeeRepository departmentEmployeeRepository;

        public UnitOfWork(ApplicationContext context)
        {
            this.context = context;
        }

        public IDepartmentRepository DepartmentRepository
        {
            get
            {
                return departmentRepository ?? (departmentRepository = new DepartmentRepository(context));
            }
        }

        public IEmployeeRepository EmployeeRepository
        {
            get
            {
                return employeeRepository ?? (employeeRepository = new EmployeeRepository(context));
            }
        }

        public IProblemRepository ProblemRepository
        {
            get
            {
                return problemRepository ?? (problemRepository = new ProblemRepository(context));
            }
        }

        public IDepartmentEmployeeRepository DepartmentEmployeeRepository
        {
            get
            {
                return departmentEmployeeRepository ?? (departmentEmployeeRepository = new DepartmentEmployeeRepository(context));
            }
        }

        public void Commit()
        {
            context.SaveChanges();
        }
    }
}

