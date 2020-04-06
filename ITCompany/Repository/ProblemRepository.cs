using ITCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCompany.Repository
{
    public class ProblemRepository : IRepository<Problem>
    {
        ICollection<Problem> problems;
        public ProblemRepository()
        {
            this.problems = Data.problems;
        }
        public void DeleteById(int Id)
        {
            Problem employee = problems.FirstOrDefault(p => p.Id == Id);
            problems.Remove(employee);
        }

        public IEnumerable<Problem> GetAll()
        {
            return problems;
        }

        public Problem GetById(int Id)
        {
            return problems.FirstOrDefault(p => p.Id == Id);
        }

        public void Insert(Problem entity)
        {
            problems.Add(entity);
        }

        public void Update(Problem entity)
        {
            Problem problem = problems.FirstOrDefault(p => p.Id == entity.Id);
            problems.Remove(problem);
            problems.Add(entity);
        }
    }
}
