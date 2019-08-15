# ASPBestBuy
A project that tests ability to use and display information from a database through a browser using ASP.


## Instructions
1. Clone the repository and create a branch to work on.
2. Start by creating a json file to store your connection string, and making sure it is hidden by git.
3. Grab your connection string from the json file and into a string in the main method.
4. Create 4 classes:
   * Sales - will contain a property for each field / column in the sales table in the bestbuy database.
   * Employees - will contain a property for each field / column in the employees table in the bestbuy database.
   * SalesRepo - will contain the 4 CRUD operations for the sales table.
   * EmployeesRepo - will contain the 4 CRUD operations for the employees table.
5. The two repo classes will need constructors that take in a connection string.
6. Create views and the connections between them:
   * Main View - Displays all employees and their information.
   * Sales View - Clicking on an employee from the list/ table should take you to a view containing their sales.
   * Employee Create View - Allows the creation of an employee.
   * Employee Update View - Allows the updating of an employee.
   * Sales Create View - Allows the creation of a sale for a particular employee.
   * Sales Update View - Allows the updating of a sale for a particular employee.
   
Make sure you are making commits along the way!
When you are done, push your branch to github and create a pull request. **Do not merge!**

**Bonus: Include a way to delete employees and their sales**
