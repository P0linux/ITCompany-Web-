using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITCompany.Business.Interfaces;
using ITCompany.Business.Services;
using ITCompany.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITCompany.Controllers
{
    public class FindEmployeeController : Controller
    {
        IEmployeeService employeeService;
        public FindEmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        [HttpGet]
        public ActionResult FindEmployee()
        {
            return View("FindEmployee", new List<Employee>());
        }

        [HttpPost]
        public IActionResult FindEmployee(string option, string findtype)
        {
            IEnumerable<Employee> employees = GetByOption(option, findtype);
            return View("FindEmployee", employees);
        }

        private IEnumerable<Employee> GetByOption(string option, string findtype)
        {
            //Data.LoadData();
            switch (findtype)
            {
                case "Name":
                    return employeeService.FindByName(option);
                case "Date":
                    return employeeService.FindByDate(option);
                case "Problem":
                    return employeeService.FindByProblem(option);
                case "DepName":
                    return employeeService.FindByDepartmentName(option);
                default:
                    break;
            }

            return null;
        }
    }
}