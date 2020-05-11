using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiApp.Data.RepositoryInterfaces
{
    public interface IRepository<ClassType, TKey>
    {
        IEnumerable<ClassType> GetAll();
        void Insert(ClassType entity);
        void Update(ClassType entity);
        ClassType GetById(TKey Id);
        void DeleteById(TKey Id);
    }
}
