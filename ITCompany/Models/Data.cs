using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCompany.Models
{
    public static class Data
    {
        public static List<Employee> employees = new List<Employee>();
        public static List<Department> departments;
        public static List<Problem> problems = new List<Problem>();
        public static List<DepartmentEmployee> departmentEmployees;

        public static void LoadData()
        {
            Employee emp = new Employee("Name", "21.12.2000");
            Problem pr = new Problem("Problem");
            problems.Add(pr);
            emp.Problems.Add(pr);
            employees.Add(emp);
        }
    }
}
