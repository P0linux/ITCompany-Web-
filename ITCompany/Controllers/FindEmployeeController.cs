using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ITCompany.Controllers
{
    public class FindEmployeeController : Controller
    {
        public ActionResult FindEmployee()
        {
            return View();
        }
    }
}