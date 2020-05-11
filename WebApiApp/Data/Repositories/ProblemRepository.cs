using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiApp.Data.Entities;
using WebApiApp.Data.RepositoryInterfaces;

namespace WebApiApp.Data.Repositories
{
    public class ProblemRepository:IProblemRepository
    {
        DbSet<Problem> problems;
        
        public ProblemRepository(ApplicationContext context)
        {
            problems = context.Set<Problem>();
        }
        public void DeleteById(int Id)
        {
            Problem employee = problems.Find(Id);
            problems.Remove(employee);
        }

        public IEnumerable<Problem> GetAll()
        {
            return problems.AsNoTracking();
        }

        public Problem GetById(int Id)
        {
            return problems.Find(Id);
        }

        public void Insert(Problem entity)
        {
            problems.Add(entity);
        }

        public void Update(Problem entity)
        {
            problems.Update(entity);
        }
    }
}
