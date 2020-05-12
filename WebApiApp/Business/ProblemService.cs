using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiApp.Business.Interfaces;
using WebApiApp.Data;
using WebApiApp.Data.Entities;
using WebApiApp.Models;

namespace WebApiApp.Business
{
    public class ProblemService:IProblemService
    {
        IUnitOfWork unitOfWork;
        IMapper mapper;


        public ProblemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<ProblemModel> GetAll()
        {
            var problems = unitOfWork.ProblemRepository.GetAll();
            return mapper.Map<IEnumerable<ProblemModel>>(problems);
        }

        public void DeleteById(int Id)
        {
            unitOfWork.ProblemRepository.DeleteById(Id);
            unitOfWork.Commit();
        }

        public ProblemModel GetById(int Id)
        {
            var problem = unitOfWork.ProblemRepository.GetById(Id);
            return mapper.Map<ProblemModel>(problem);
        }

        public void Update(ProblemModel problem)
        {
            var pr = mapper.Map<Problem>(problem);
            unitOfWork.ProblemRepository.Update(pr);
            unitOfWork.Commit();
        }

        public void Create(ProblemModel problem)
        {
            var pr = mapper.Map<Problem>(problem);
            unitOfWork.ProblemRepository.Insert(pr);
            unitOfWork.Commit();
        }
    }
}
