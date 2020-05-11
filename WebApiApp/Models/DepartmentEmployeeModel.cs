using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiApp.Models
{
    public class DepartmentEmployeeModel
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int EmployeeId { get; set; }
        public DepartmentModel Department { get; set; }
        public EmployeeModel Employee { get; set; }

        public DepartmentEmployeeModel()
        {

        }
        public DepartmentEmployeeModel(int dId, int eId)
        {
            DepartmentId = dId;
            EmployeeId = eId;
        }
    }
}
