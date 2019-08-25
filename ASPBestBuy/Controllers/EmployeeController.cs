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

        public IActionResult CreateNewEmployee(Employee newEmployee)
        {
            EmployeeRepo er = new EmployeeRepo();
            er.CreateEmployee(newEmployee);
            return RedirectToAction("Index");
        }

        public IActionResult CreateEmployeePage()
        {
            return View();
        }

        public IActionResult UpdateEmployee(Employee updateEmployeeInfo)
        {
            EmployeeRepo er = new EmployeeRepo();
            er.UpdateEmployee(updateEmployeeInfo);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateEmployeePage(int updateEmployeeInfo)
        {
            //create new employee and pass id to View
            EmployeeViewModel evm = new EmployeeViewModel();
            evm.EmployeeID = updateEmployeeInfo;

            return View(evm);
        }
       
        public IActionResult DeleteEmployee(int deleteEmployeeInfo)
        {
            SaleRepo sr = new SaleRepo();
            sr.DeleteSales(deleteEmployeeInfo);
            EmployeeRepo er = new EmployeeRepo();
            er.DeleteEmployee(deleteEmployeeInfo );
          
            return RedirectToAction("Index");

            

        }
    }

}
