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
        public IActionResult ViewSales(int salesToView)
        {
            SaleRepo sr = new SaleRepo();
            SaleViewModel svm = new SaleViewModel();
            svm.SalesList = sr.ViewSales(salesToView);

            return View(svm);
        }

    }
}