using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCompany.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public List<Problem> Problems { get; set; } = new List<Problem>();

        public Employee() { }
        public Employee(string name, string date)
        {
            Name = name;
            DateOfBirth = date;
        }
    }
}
