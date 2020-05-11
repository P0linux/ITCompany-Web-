using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiApp.Data.Entities;

namespace WebApiApp.Data.RepositoryInterfaces
{
    public interface IEmployeeRepository:IRepository<Employee, int>
    {
    }
}
