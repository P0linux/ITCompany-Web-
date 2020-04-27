using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCompany.Data.Entities
{
    public class EmployeeEntity : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public ICollection<ProblemEntity> Problems { get; set; }
    }
}
