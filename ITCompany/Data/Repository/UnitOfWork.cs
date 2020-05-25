using ITCompany.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCompany.Data.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationContext context;
        private DepartmentRepository departmentRepository;
        private EmployeeRepository employeeRepository;
        private ProblemRepository problemRepository;
        private DepartmentEmployeeRepository departmentEmployeeRepository;

        public UnitOfWork(ApplicationContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.context = context;
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public UserManager<User> UserManager { get; }
        public SignInManager<User> SignInManager { get; set; }

        public DepartmentRepository DepartmentRepository
        {
            get
            {
                return departmentRepository ?? (departmentRepository = new DepartmentRepository(context));
            }
        }

        public EmployeeRepository EmployeeRepository
        {
            get
            {
                return employeeRepository ?? (employeeRepository = new EmployeeRepository(context));
            }
        }

        public ProblemRepository ProblemRepository
        {
            get
            {
                return problemRepository ?? (problemRepository = new ProblemRepository(context));
            }
        }

        public DepartmentEmployeeRepository DepartmentEmployeeRepository
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
