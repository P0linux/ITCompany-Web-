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
    public class EmployeeController : ControllerBase
    {
        IEmployeeService employeeService;
        public EmployeeController(IEmployeeService service)
        {
            employeeService = service;
        }

        [HttpGet]
        public IEnumerable<EmployeeModel> Get()
        {
            return employeeService.GetAll();
        }

        [HttpGet("{Id}")]
        public ActionResult<EmployeeModel> Get(int Id)
        {
            EmployeeModel employee = employeeService.GetById(Id);
            if (employee == null) return NotFound();
            return new ObjectResult(employee);
        }

        //[HttpGet("{name}")]
        //public ActionResult<IEnumerable<EmployeeModel>> GetByName(string name)
        //{
        //    var employee = employeeService.FindByName(name);
        //    if (employee == null) return NotFound();
        //    return new ObjectResult(employee);
        //}

        //[HttpGet("{date}")]
        //public ActionResult<IEnumerable<EmployeeModel>> GetByDate(string date)
        //{
        //    var employee = employeeService.FindByDate(date);
        //    if (employee == null) return NotFound();
        //    return new ObjectResult(employee);
        //}

        //[HttpGet("{problem}")]
        //public ActionResult<IEnumerable<EmployeeModel>> GetByProblem(string problem)
        //{
        //    var employee = employeeService.FindByProblem(problem);
        //    if (employee == null) return NotFound();
        //    return new ObjectResult(employee);
        //}

        //[HttpGet("{department}")]
        //public ActionResult<IEnumerable<EmployeeModel>> GetByDepartment(string department)
        //{
        //    var employee = employeeService.FindByDepartmentName(department);
        //    if (employee == null) return NotFound();
        //    return new ObjectResult(employee);
        //}

        [HttpPut]
        public ActionResult<EmployeeModel> Put([FromBody]EmployeeModel employee)
        {
            if (employee == null) return BadRequest();
            if (!employeeService.GetAll().Any(e => e.Id == employee.Id)) return NotFound();
            employeeService.Update(employee);
            return Ok(employee);
        }

        [HttpDelete("{Id}")]
        public ActionResult<EmployeeModel> Delete(int Id)
        {
            EmployeeModel problem = employeeService.GetById(Id);
            if (problem == null) return NotFound();
            employeeService.DeleteById(Id);
            return Ok(problem);
        }

        [HttpPost]
        public ActionResult<EmployeeModel> Post(EmployeeModel employee)
        {
            if (employee == null) return BadRequest();
            employeeService.Create(employee);
            return Ok(employee);
        }
    }
}