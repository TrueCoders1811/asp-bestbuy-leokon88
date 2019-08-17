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
                    "DateOfBirth FROM Employees;";
                return connect.Query<Employee>(sqlCmd).ToList();  //Query  - Dapper method .ToList - Linq method allows to convert arrays to list
            }
        }


        public void CreateEmployee(Employee createEmployee)
        {
            MySqlConnection connect = new MySqlConnection(ConnectionString);
            using (connect)
            {
                connect.Open();
                string sqlCmd = "INSERT INTO Employees(EmployeeID, FirstName, MiddleInitial,LastName,EmailAddress,PhoneNumber" +
                    "Title,DateOfBirth)(@fName, @mI,@lName,@email,@number,@title,@bDate);";
                connect.Execute(sqlCmd, createEmployee);
            }
        }

        public void UpdateEmployee(Employee updateEmployee)
        {
            MySqlConnection connect = new MySqlConnection(ConnectionString);
            using (connect)
            {
                connect.Open();
                string sqlCmd = "UPDATE Title, PhoneNumber FROM Employees;";
                connect.Execute(sqlCmd, updateEmployee);
            }
                    }

        public void DeleteEmployee(int deleteEmployeeID)
        {
            MySqlConnection connect = new MySqlConnection(ConnectionString);
            using (connect)
            {
                connect.Open();
                string sqlCmd = "Delete From Employees WHERE EmployeeID = @EmpID)";
                connect.Execute(sqlCmd, new { deleteEmployeeID });//pass anonymous type (class) since we are not passing entire sales
            }
        }
    }
}
