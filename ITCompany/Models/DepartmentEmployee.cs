using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCompany.Models
{
    public class DepartmentEmployee
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int EmployeeId { get; set; }
        public Department Department { get; set; }
        public Employee Employee { get; set; }

        public DepartmentEmployee(int dId, int eId, Department department, Employee employee)
        {
            DepartmentId = dId;
            EmployeeId = eId;
            Department = department;
            Employee = employee;
        }
    }
}
