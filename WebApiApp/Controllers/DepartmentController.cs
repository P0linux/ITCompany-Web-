using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiApp.Business;
using WebApiApp.Business.Interfaces;
using WebApiApp.Models;

namespace WebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        IDepartmentService departmentService;
        public DepartmentController(IDepartmentService service)
        {
            departmentService = service;
        }

        [HttpGet]
        public IEnumerable<DepartmentModel> Get()
        {
            return departmentService.GetAll();
        }

        [HttpGet("{Id}")]
        public ActionResult<DepartmentModel> Get(int Id)
        {
            DepartmentModel department = departmentService.GetById(Id);
            if (department == null) return NotFound();
            return new ObjectResult(department);
        }

        [HttpPut]
        public ActionResult<DepartmentModel> Put([FromBody]DepartmentModel department)
        {
            if (department == null) return BadRequest();
            if (!departmentService.GetAll().Any(e => e.Id == department.Id)) return NotFound();
            departmentService.Update(department);
            return Ok(department);
        }

        [HttpDelete("{Id}")]
        public ActionResult<DepartmentModel> Delete(int Id)
        {
            DepartmentModel department = departmentService.GetById(Id);
            if (department == null) return NotFound();
            departmentService.DeleteById(Id);
            return Ok(department);
        }

        [HttpPost]
        public ActionResult<DepartmentModel> Post(DepartmentModel department)
        {
            if (department == null) return BadRequest();
            departmentService.Create(department);
            return Ok(department);
        }
    }
}