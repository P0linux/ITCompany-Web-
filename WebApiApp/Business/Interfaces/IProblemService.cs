using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiApp.Models;

namespace WebApiApp.Business.Interfaces
{
    public interface IProblemService
    {
        IEnumerable<ProblemModel> GetAll();
        ProblemModel GetById(int Id);
        void DeleteById(int Id);
        void Create(ProblemModel problem);
        void Update(ProblemModel problem);
    }
}
