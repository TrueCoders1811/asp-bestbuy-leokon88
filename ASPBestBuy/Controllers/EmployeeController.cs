using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPBestBuy.Models;

namespace ASPBestBuy.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            EmployeeRepo er = new EmployeeRepo();
            EmployeeViewModel evm = new EmployeeViewModel();
            evm.EmployeeList = er.GetEmployee();

            return View(evm);
        }

        public IActionResult CreateNewEmployee()
        {
            return View();
        }
    }
}
