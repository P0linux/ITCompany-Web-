using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiApp.Data.Entities
{
    public class Department:IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Department() { }
        public Department(string name)
        {
            Name = name;
        }
    }
}
