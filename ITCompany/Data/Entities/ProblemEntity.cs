using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCompany.Data.Entities
{
    public class ProblemEntity : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeEntity Employee { get; set; }
    }
}
