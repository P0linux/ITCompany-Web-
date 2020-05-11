using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiApp.Data.Entities
{
    public class DepartmentEmployee:IBaseEntity
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int EmployeeId { get; set; }
        public Department Department { get; set; }
        public Employee Employee { get; set; }

        public DepartmentEmployee() {}
        public DepartmentEmployee(int dId, int eId)
        {
            DepartmentId = dId;
            EmployeeId = eId;
        }
    }
}
