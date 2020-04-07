using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITCompany.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITCompany.Controllers
{
    public class CreateController : Controller
    {
        [HttpGet]
        public ActionResult CreateEmployee()
        {
            ViewData["EmployeeParameters"] = new EmployeeParameters();
            return View("CreateEmployee");
        }
        [HttpPost]
        public ActionResult CreateEmployee(EmployeeParameters parameters)
        {
            return View("CreateEmployee");
        }
    }
}