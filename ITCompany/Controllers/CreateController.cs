using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITCompany.Business.Services;
using ITCompany.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITCompany.Controllers
{
    public class CreateController : Controller
    {
        
        CreatorService creatorService;
        public CreateController(CreatorService creatorService)
        {
            this.creatorService = creatorService;
        }

        [HttpGet]
        public ActionResult CreateEmployee()
        {
            return View("CreateEmployee", new EmployeeParameters());
        }
        [HttpPost]
        public ActionResult CreateEmployee(string problems, EmployeeParameters parameters)
        {
            parameters.Problems = problems.Split(",").ToList();
            creatorService.CreateEmployee(parameters);
            return RedirectToAction("CreateEmployee");
        }

        [HttpGet]
        public ActionResult CreateDepartment()
        {
            return View("CreateDepartment", new Department());
        }

        [HttpPost]
        public ActionResult CreateDepartment(Department department)
        {
            creatorService.CreateDepartment(department);
            return RedirectToAction("CreateDepartment");
        }

        [HttpGet]
        public ActionResult CreateProblem()
        {
            return View("CreateProblem", new Problem());
        }

        [HttpPost]
        public ActionResult CreateProblem(Problem problem)
        {
            creatorService.CreateProblem(problem);
            return RedirectToAction("CreateProblem");
        }
    }
}