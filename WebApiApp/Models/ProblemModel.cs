using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiApp.Models
{
    public class ProblemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeModel Employee { get; set; }

        public ProblemModel(string name)
        {
            Name = name;
        }

        public ProblemModel() { }
    }
}
