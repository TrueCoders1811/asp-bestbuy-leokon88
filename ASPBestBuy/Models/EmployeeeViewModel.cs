using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPBestBuy.Models
{
    public class EmployeeViewModel
    {
        public List<Employee> EmployeeList { get; set; } = new List<Employee>();

        public int EmployeeID { get; set; }
    }
    
}

