using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPBestBuy.Models;

namespace ASPBestBuy.Controllers
{
    public class SaleController : Controller
    {
        public IActionResult ViewSales(int empID)
        {
            SaleRepo sr = new SaleRepo();
            SaleViewModel svm = new SaleViewModel();
            svm.SalesList = sr.ViewSales(empID);
            svm.EmployeeID = empID;
            return View(svm);
        }

        public IActionResult CreateSalePage(int empID)  // retrieve as parameter
        {
          
            SaleViewModel svm = new SaleViewModel();
            svm.EmployeeID = empID;
            return View(svm); // send data  to the View
        }

        
        public IActionResult CreateSale(Sale createNewSale)
        {
            SaleRepo sr = new SaleRepo();
            sr.CreateSales(createNewSale);
            return RedirectToAction("ViewSales", new { empID=createNewSale.EmployeeID });
        }
     

    }
}