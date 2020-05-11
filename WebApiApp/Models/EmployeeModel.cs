using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiApp.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public List<ProblemModel> Problems { get; set; } = new List<ProblemModel>();

        public EmployeeModel() { }
        public EmployeeModel(string name, string date)
        {
            Name = name;
            DateOfBirth = date;
        }
    }
}
