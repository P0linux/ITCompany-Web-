using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCompany.Models
{
    public class EmployeeParameters
    {
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public List<string> Problems { get; set; }
        public string DepartmentName { get; set; }
    }
}
