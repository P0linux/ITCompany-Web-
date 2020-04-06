using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCompany.Repository
{
    interface IRepository<ClassType>
    {
        IEnumerable<ClassType> GetAll();
        void Insert(ClassType entity);
        void Update(ClassType entity);
        ClassType GetById(int Id);
        void DeleteById(int Id);
    }
}
