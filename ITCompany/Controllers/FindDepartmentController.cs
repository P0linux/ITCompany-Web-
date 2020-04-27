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
    public class FindDepartmentController : Controller
    {
        IDepartmentService departmentService;
        public FindDepartmentController(IDepartmentService employeeService)
        {
            this.departmentService = employeeService;
        }
        [HttpGet]
        public ActionResult FindDepartment()
        {
            return View("FindDepartment", new List<Department>());
        }

        [HttpPost]
        public IActionResult FindDepartment(string option, string findtype)
        {
            IEnumerable<Department> departments = GetByOption(option, findtype);
            return View("FindDepartment", departments);
        }

        private IEnumerable<Department> GetByOption(string option, string findtype)
        {
            //Data.LoadData();
            switch (findtype)
            {
                case "Name":
                    return departmentService.FindByName(option);
                case "Employee":
                    return departmentService.FindByEmployee(option);
                case "Problem":
                    return departmentService.FindByProblem(option);
                default:
                    break;
            }

            return null;
        }
    }
}