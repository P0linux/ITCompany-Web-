using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCompany.Repository
{
    public class UnitOfWork
    {
        private DepartmentRepository departmentRepository;
        private EmployeeRepository employeeRepository;
        private ProblemRepository problemRepository;
        private DepartmentEmployeeRepository departmentEmployeeRepository;

        public DepartmentRepository DepartmentRepository
        {
            get
            {
                return departmentRepository ?? (departmentRepository = new DepartmentRepository());
            }
        }

        public EmployeeRepository EmployeeRepository
        {
            get
            {
                return employeeRepository ?? (employeeRepository = new EmployeeRepository());
            }
        }

        public ProblemRepository ProblemRepository
        {
            get
            {
                return problemRepository ?? (problemRepository = new ProblemRepository());
            }
        }

        public DepartmentEmployeeRepository DepartmentEmployeeRepository
        {
            get
            {
                return departmentEmployeeRepository ?? (departmentEmployeeRepository = new DepartmentEmployeeRepository());
            }
        }

    }
}
