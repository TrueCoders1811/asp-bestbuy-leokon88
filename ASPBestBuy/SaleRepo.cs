﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPBestBuy.Models;
using Dapper;
using MySql.Data.MySqlClient;


namespace ASPBestBuy
{
    public class SaleRepo
    {
        public static string ConnectionString { get; set; }

        public void CreateSales(Sale newSale)
        {
            MySqlConnection connect = new MySqlConnection(ConnectionString);
            using (connect)
            {
                connect.Open();
                string sqlCmd = "INSERT INTO Sales( ProductID, Quantity, Price,Date,EmployeeID)"
                    + "VALUES(@ProductID, @Quantity, @Price,@Date,@EmployeeID);";
                connect.Execute(sqlCmd, newSale);
            }
        }

        public void DeleteAllSales(int employeeId)// delete sales by EmployeeID
        {
            MySqlConnection connect = new MySqlConnection(ConnectionString);
            using (connect)
            {
               string sqlCmd = "Delete From sales WHERE EmployeeID = @EmployeeId;";
                connect.Execute(sqlCmd, new { employeeId });//pass anonymous type (class) since we are not passing entire sales
            }
        }

        public void DeleteSale(int salesId)// delete sales by EmployeeID
        {
            MySqlConnection connect = new MySqlConnection(ConnectionString);
            using (connect)
            {
                connect.Open();
                string sqlCmd = "Delete From sales WHERE SalesID = @salesId;";  // right side match Sql column --left side retrieved parameter
                connect.Execute(sqlCmd, new { salesId });//pass anonymous type (class) since we are not passing entire sales
            }
        }

        public List<Sale> ViewSales(int empID)
        {
            MySqlConnection connect = new MySqlConnection(ConnectionString);
            using (connect)
            {
                connect.Open();
                string sqlCmd = "SELECT SalesID, ProductID, Quantity, Price,Date,EmployeeID FROM Sales WHERE EmployeeID like @empID;";//names must match exactly as specified in Class
                return connect.Query<Sale>(sqlCmd, new { empID }).ToList();  //Query  - Dapper method .ToList - Linq method allows to convert arrays to list
            }
        }

        public void UpdateSales(Sale sales)
        {
            MySqlConnection connect = new MySqlConnection(ConnectionString);
            using (connect)
            {
                connect.Open();
                string sqlCmd = "UPDATE SalesID, ProductID FROM Sales";
                connect.Execute(sqlCmd, sales);
            }
        }



    }
}
