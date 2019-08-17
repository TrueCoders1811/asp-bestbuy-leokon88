using System;
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

        public void CreateSales(Sale sales)
        {
            MySqlConnection connect = new MySqlConnection(ConnectionString);
            using (connect)
            {
                connect.Open();
                string sqlCmd = "INSERT INTO Sales( ProductID, Quantity, Price,Date,EmployeeID)"
                    + "VALUES(@SalesID,@ProductId, @Quantity, @Price,@Date,@EmployeesId)";
                connect.Execute(sqlCmd, sales);
            }
        }

        public void DeleteSales(int saleId)
        {
            MySqlConnection connect = new MySqlConnection(ConnectionString);
            using (connect)
            {
                connect.Open();
                string sqlCmd = "Delete From sales WHERE salesId = @SaleID)";
                connect.Execute(sqlCmd, new { saleId });//pass anonymous type (class) since we are not passing entire sales
            }
        }

        public List<Sale> GetSales()
        {
            MySqlConnection connect = new MySqlConnection(ConnectionString);
            using (connect)
            {
                connect.Open();
                string sqlCmd = "SELECT SalesID, ProductID, Quantity, Price,Date,EmployeeID FROM Sales";//names must match exactly as specified in Class
                return connect.Query<Sale>(sqlCmd).ToList();  //Query  - Dapper method .ToList - Linq method allows to convert arrays to list
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
