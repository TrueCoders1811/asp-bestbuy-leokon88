using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPBestBuy.Models
{
    public class SaleViewModel
    {
        public List<Sale> SalesList { get; set; } = new List<Sale>();

        public int EmployeeID { get; set; } //for Creating a new sale
     
        public int SaleID { get; set; }  //for updating sale
    }
}
