using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiApp.Data;
using WebApiApp.Data.Entities;
using WebApiApp.Models;

namespace WebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProblemController : ControllerBase
    {
        IUnitOfWork unitOfWork;
        IMapper mapper;
        public ProblemController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ProblemModel> Get()
        {
            return mapper.Map<List<ProblemModel>>(unitOfWork.ProblemRepository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<ProblemModel> Get(int id)
        {
            ProblemModel problem = mapper.Map<ProblemModel>(unitOfWork.ProblemRepository.GetById(id));
            if (problem == null) return NotFound();
            return new ObjectResult(problem);
        }

        [HttpPost]
        public ActionResult<ProblemModel> Post(ProblemModel problem)
        {
            if (problem == null) return BadRequest();
            unitOfWork.ProblemRepository.Insert(mapper.Map<Problem>(problem));
            unitOfWork.Commit();
            return Ok(problem);
        }

        [HttpPut("{Id}")]
        public ActionResult<ProblemModel> Put(int Id, [FromBody]ProblemModel problem)
        {
            if (problem == null) return BadRequest();
            if (unitOfWork.ProblemRepository.GetById(Id) == null) return NotFound();
            unitOfWork.ProblemRepository.Update(mapper.Map<Problem>(problem));
            unitOfWork.Commit();
            return Ok(problem);
        }

        [HttpDelete("{Id}")]
        public ActionResult<ProblemModel> Delete(int Id)
        {
            ProblemModel problem = mapper.Map<ProblemModel>(unitOfWork.ProblemRepository.GetById(Id));
            if (problem == null) return NotFound();
            unitOfWork.ProblemRepository.DeleteById(Id);
            unitOfWork.Commit();
            return Ok(problem);
        }
    }
}