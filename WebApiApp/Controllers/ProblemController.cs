using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiApp.Business.Interfaces;
using WebApiApp.Data;
using WebApiApp.Data.Entities;
using WebApiApp.Models;

namespace WebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProblemController : ControllerBase
    {
        IProblemService problemService;
        public ProblemController(IProblemService service)
        {
            problemService = service;
        }

        [HttpGet]
        public IEnumerable<ProblemModel> Get()
        {
            return problemService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<ProblemModel> Get(int id)
        {
            ProblemModel problem = problemService.GetById(id);
            if (problem == null) return NotFound();
            return new ObjectResult(problem);
        }

        [HttpPost]
        public ActionResult<ProblemModel> Post(ProblemModel problem)
        {
            if (problem == null) return BadRequest();
            problemService.Create(problem);
            return Ok(problem);
        }

        [HttpPut]
        public ActionResult<ProblemModel> Put([FromBody]ProblemModel problem)
        {
            if (problem == null) return BadRequest();
            if (!problemService.GetAll().Any(e => e.Id == problem.Id)) return NotFound();
            problemService.Update(problem);
            return Ok(problem);
        }

        [HttpDelete("{Id}")]
        public ActionResult<ProblemModel> Delete(int Id)
        {
            ProblemModel problem = problemService.GetById(Id);
            if (problem == null) return NotFound();
            problemService.DeleteById(Id);
            return Ok(problem);
        }
    }
}