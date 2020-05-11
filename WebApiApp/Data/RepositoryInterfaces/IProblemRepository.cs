using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiApp.Data.Entities;

namespace WebApiApp.Data.RepositoryInterfaces
{
    public interface IProblemRepository:IRepository<Problem, int>
    {
        
    }
}
