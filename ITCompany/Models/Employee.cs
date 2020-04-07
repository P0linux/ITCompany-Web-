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
        public DateTime DateOfBirth { get; set; }
        public List<Problem> Problems { get; set; }

        public Employee(string name, DateTime date)
        {
            Name = name;
            DateOfBirth = date;
        }
    }
}
