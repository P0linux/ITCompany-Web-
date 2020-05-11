using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiApp.Data.Entities
{
    public class Problem:IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public Problem(string name)
        {
            Name = name;
        }

        public Problem() { }
    }
}
