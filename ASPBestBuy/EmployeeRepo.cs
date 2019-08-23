using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPBestBuy.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace ASPBestBuy
{
    public class EmployeeRepo
    {
        public static string ConnectionString { get; set; }

        public List<Employee> GetEmployee()
        {
            MySqlConnection connect = new MySqlConnection(ConnectionString);
            using (connect)
            {
                connect.Open();
                string sqlCmd = "SELECT EmployeeID, FirstName,MiddleInitial, LastName, EmailAddress, PhoneNumber, Title," +
                    "DateOfBirth FROM Employees ORDER BY EmployeeID DESC  ;";
                return connect.Query<Employee>(sqlCmd).ToList();  //Query  - Dapper method .ToList - Linq method allows to convert arrays to list
            }
        }


        public void CreateEmployee(Employee createEmployee)
        {
            MySqlConnection connect = new MySqlConnection(ConnectionString);
            using (connect)
            {
                connect.Open();
                string sqlCmd = "INSERT INTO Employees(FirstName, MiddleInitial,LastName,EmailAddress,PhoneNumber,Title,DateOfBirth) " +
                    "VALUES(@FirstName, @MiddleInitial,@LastName,@EmailAddress,@PhoneNumber, @Title,@DateOfBirth);";
                connect.Execute(sqlCmd, createEmployee);
            }
        }

        public void UpdateEmployee(Employee updateEmployeeByID)
        {
            MySqlConnection connect = new MySqlConnection(ConnectionString);
            using (connect)
            {
                connect.Open();
                string sqlCmd = "UPDATE Employees SET FirstName=@FirstName, MiddleInitial=@MiddleInitial,LastName=@LastName," +
                    "EmailAddress=@EmailAddress,PhoneNumber=@PhoneNumber,Title= @Title, DateOfBirth=@DateOfBirth " +
                    "WHERE EmployeeID=@EmployeeID;";
                connect.Execute(sqlCmd,  updateEmployeeByID);
            }
        }

        public void DeleteEmployee(int deleteEmployeeId)
        {
            MySqlConnection connect = new MySqlConnection(ConnectionString);
            using (connect)
            {
                connect.Open();
                string sqlCmd = "Delete From Employees WHERE EmployeeID=@deleteEmployeeId;";
                connect.Execute(sqlCmd, new { deleteEmployeeId });
            }
        }
    }
}
