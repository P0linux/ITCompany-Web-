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
    public class DepartmentEmployeeService:IDepartmentEmployeeService
    {
        IUnitOfWork unitOfWork;
        IMapper mapper;

        public DepartmentEmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<DepartmentEmployeeModel> GetAll()
        {
            var depemps = unitOfWork.DepartmentEmployeeRepository.GetAll();
            return mapper.Map<IEnumerable<DepartmentEmployeeModel>>(depemps);
        }

        public void DeleteById(int Id)
        {
            unitOfWork.DepartmentEmployeeRepository.DeleteById(Id);
            unitOfWork.Commit();
        }

        public DepartmentEmployeeModel GetById(int Id)
        {
            var depemp = unitOfWork.DepartmentEmployeeRepository.GetById(Id);
            return mapper.Map<DepartmentEmployeeModel>(depemp);
        }

        public void Update(DepartmentEmployeeModel depemp)
        {
            var emp = mapper.Map<DepartmentEmployee>(depemp);
            unitOfWork.DepartmentEmployeeRepository.Update(emp);
            unitOfWork.Commit();
        }

        public void Create(DepartmentEmployeeModel depemp)
        {
            var emp = mapper.Map<DepartmentEmployee>(depemp);
            unitOfWork.DepartmentEmployeeRepository.Insert(emp);
            unitOfWork.Commit();
        }
    }
}
