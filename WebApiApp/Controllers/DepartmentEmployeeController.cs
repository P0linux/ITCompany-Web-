using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiApp.Business.Interfaces;
using WebApiApp.Models;

namespace WebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentEmployeeController : ControllerBase
    {
        IDepartmentEmployeeService depempService;
        public DepartmentEmployeeController(IDepartmentEmployeeService service)
        {
            depempService = service;
        }

        [HttpGet]
        public IEnumerable<DepartmentEmployeeModel> Get()
        {
            return depempService.GetAll();
        }

        [HttpGet("{Id}")]
        public ActionResult<DepartmentEmployeeModel> Get(int Id)
        {
            DepartmentEmployeeModel department = depempService.GetById(Id);
            if (department == null) return NotFound();
            return new ObjectResult(department);
        }

        [HttpPut]
        public ActionResult<DepartmentEmployeeModel> Put([FromBody]DepartmentEmployeeModel department)
        {
            if (department == null) return BadRequest();
            if (!depempService.GetAll().Any(e => e.Id == department.Id)) return NotFound();
            depempService.Update(department);
            return Ok(department);
        }

        [HttpDelete("{Id}")]
        public ActionResult<DepartmentEmployeeModel> Delete(int Id)
        {
            DepartmentEmployeeModel department = depempService.GetById(Id);
            if (department == null) return NotFound();
            depempService.DeleteById(Id);
            return Ok(department);
        }

        [HttpPost]
        public ActionResult<DepartmentEmployeeModel> Post(DepartmentEmployeeModel department)
        {
            if (department == null) return BadRequest();
            depempService.Create(department);
            return Ok(department);
        }
    }
}