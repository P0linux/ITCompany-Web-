using ITCompany.Data.Entities;
using ITCompany.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCompany.Data.Repository
{
    public class ProblemRepository : IRepository<ProblemEntity>
    {
        DbSet<ProblemEntity> problems;
        public ProblemRepository(ApplicationContext context)
        {
            problems = context.Set<ProblemEntity>();
        }
        public void DeleteById(int Id)
        {
            ProblemEntity employee = problems.Find(Id);
            problems.Remove(employee);
        }

        public IEnumerable<ProblemEntity> GetAll()
        {
            return problems;
        }

        public ProblemEntity GetById(int Id)
        {
            return problems.Find(Id);
        }

        public void Insert(ProblemEntity entity)
        {
            problems.Add(entity);
        }

        public void Update(ProblemEntity entity)
        {
            problems.Update(entity);
        }
    }
}
