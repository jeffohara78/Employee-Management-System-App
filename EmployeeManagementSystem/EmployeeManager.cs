using System;
using System.Collections.Generic;

namespace EmployeeManagementSystem
{
    // This class manages all employee related actions
    public class EmployeeManager
    {
        // Stores all employees in memory while the program is running
        private List<Employee> employees = new List<Employee> ();

        // Used to automatically assign each employee a unique ID
        private int nextEmployeeId = 1001;

        // Adds a new employee to the system
        public void AddEmployee()
        { 
            Console.WriteLine("\n--- Add New Employee ---");
            Console.WriteLine("Please enter the the employee information below.");
            Console.WriteLine("Example: First Name = Sarah, Department = IT, Salary = 60000\n");

            Console.Write("First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Department, such as IT, HR, Finance, Security, or Operations: ");
            string department = Console.ReadLine();

            Console.Write("Job Title, such as Software Developer, Analyst, or Help Desk Technician: ");
            string jobTitle = Console.ReadLine();

            decimal salary = GetSalaryFromUser();

            Employee newEmployee = new Employee(nextEmployeeId, firstName, lastName, department, jobTitle, salary);

            employees.Add(newEmployee);

            Console.WriteLine($"\nEmployee added successfully.");
            Console.WriteLine($"Assigned Employee ID: {nextEmployeeId}");

            nextEmployeeId++;

        }

        // Displays all employees.
        public void ViewAllEmployees()
        {
            Console.WriteLine("\n=== All Employees ===");

            if (employees.Count == 0)
            {
                Console.WriteLine("No employees have been added yet.");
                return;
            }

            foreach (Employee employee in employees)
            {
                DisplayEmployeeDetails(employee);
            }
        }

        // Searches employees by name, department , or job title
        public void SearchEmployees()
        {
            Console.WriteLine("\n=== Search Employees ===");
            Console.WriteLine("You can search by first name, last name, department, or job title.");
            Console.WriteLine("Example searches: Jeff, IT, Analyst, Security\n");

            Console.Write("Enter search term: ");
            string searchTerm = Console.ReadLine().ToLower();

            bool found = false;

            foreach (Employee employee in employees)
            {
                bool firstNameMatches = employee.FirstName.ToLower().Contains(searchTerm);
                bool lastNameMatches = employee.LastName.ToLower().Contains(searchTerm);
                bool departmentMatches = employee.Department.ToLower().Contains(searchTerm);
                bool jobTitleMatches = employee.JobTitle.ToLower().Contains(searchTerm);

                if (firstNameMatches || lastNameMatches || departmentMatches || jobTitleMatches)
                {
                    DisplayEmployeeDetails(employee);
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No matching employees found.");
            }
        }

        // Updates an employee's department or job title.
        public void UpdateEmployee()
        {
            Console.WriteLine("\n=== Update Employee ===");

            if (employees.Count == 0)
            {
                Console.WriteLine("There are no employees to update.");
                return;
            }

            DisplayEmployeeSummary();

            Console.Write("\nEnter the Employee ID to update, such as 1001: ");
            string input = Console.ReadLine().Trim();

            bool isValidNumber = int.TryParse(input, out int employeeId);

            if (!isValidNumber)
            {
                Console.WriteLine("Invalid input. Please enter a numeric Employee ID.");
                return;
            }

            Employee employeeToUpdate = employees.Find(employee => employee.EmployeeId == employeeId);

            if (employeeToUpdate == null)
            {
                Console.WriteLine("No employee with that ID was found.");
                return;
            }

            Console.WriteLine("\nWhat would you like to update?");
            Console.WriteLine("1. Department");
            Console.WriteLine("2. Job title");
            Console.Write("Choose option 1 or 2: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Enter new department, such as IT, HR, Finance, Security, or Operations: ");
                employeeToUpdate.Department = Console.ReadLine();

                Console.WriteLine("Department updated successfully.");
            }
            else if (choice == "2")
            {
                Console.Write("Enter new job title, such as Software Developer, Analyst, or Manager: ");
                employeeToUpdate.JobTitle = Console.ReadLine();

                Console.WriteLine("Job title updated successfully.");
            }
            else
            {
                Console.WriteLine("Invalid option. No changes were made.");
            }
        }

        // Gives an employee a percentage based raise
        public void GiveRaise()
        {
            Console.WriteLine("\n=== Give Employee Raise ===");

            if (employees.Count == 0)
            {
                Console.WriteLine("There are no employees available.");
                return;
            }

            DisplayEmployeeSummary();

            Console.Write("\nEnter the employee ID receiving the raise, such as 1001: ");
            string input = Console.ReadLine().Trim();

            bool isValidNumber = int.TryParse(input, out int employeeId);

            if (!isValidNumber)
            {
                Console.WriteLine("Invalid input. Please enter a numeric Employee ID: ");
                return;
            }

            Employee employee = employees.Find(emp => emp.EmployeeId == employeeId);

            if (employee == null)
            {
                Console.WriteLine("No employee with that ID was found.");
                return;
            }

            Console.Write("Enter raise percentage, such as 3, 5, or 7.5: ");
            string raiseInput = Console.ReadLine().Trim();

            bool isValidPercent = decimal.TryParse(raiseInput, out decimal raisePercent);

            if (!isValidPercent || raisePercent <= 0)
            {
                Console.WriteLine("Invalid raise amount. Please enter a positive number.");
                return;
            }

            decimal oldSalary = employee.Salary;

            // Convert percentage into a decimal multiplier.
            // Example: 5% becomes 0.05.
            decimal raiseAmount = employee.Salary * (raisePercent / 100);

            employee.Salary += raiseAmount;

            Console.WriteLine($"\nRaise applied successfully.");
            Console.WriteLine($"Employee: {employee.FirstName} {employee.LastName}");
            Console.WriteLine($"Old Salary: {oldSalary:C}");
            Console.WriteLine($"New Salary: {employee.Salary:C}");
        }

        // Deletes an employee by ID.
        public void DeleteEmployee()
        {
            Console.WriteLine("\n=== Delete Employee ===");

            if (employees.Count == 0)
            {
                Console.WriteLine("There are no employees to delete.");
                return;
            }

            DisplayEmployeeSummary();

            Console.Write("\nEnter the Employee ID to delete, such as 1001: ");
            string input = Console.ReadLine().Trim();

            bool isValidNumber = int.TryParse(input, out int employeeId);

            if (!isValidNumber)
            {
                Console.WriteLine("Invalid input. Please enter a numeric Employee ID.");
                return;
            }

            Employee employeeToDelete = employees.Find(employee => employee.EmployeeId == employeeId);

            if (employeeToDelete == null)
            {
                Console.WriteLine("No employee with that ID was found.");
                return;
            }

            employees.Remove(employeeToDelete);

            Console.WriteLine($"Employee {employeeToDelete.FirstName} {employeeToDelete.LastName} deleted successfully.");
        }


        // Helper method for getting salary input safely
        private decimal GetSalaryFromUser()
        {
            while (true)
            {
                Console.Write("Annual salary, numbers only, such as 65000 or 72500.50: ");
                string salaryInput = Console.ReadLine().Trim();

                bool isValidSalary = decimal.TryParse(salaryInput, out decimal salary);

                if (isValidSalary && salary > 0)
                {
                    return salary;
                }

                Console.WriteLine("Invalid salary. Please enter a positive number without dollar signs or commas.");
            }
        }

        // Displays full employee information.
        private void DisplayEmployeeDetails(Employee employee)
        {
            Console.WriteLine($"\nEmployee ID: {employee.EmployeeId}");
            Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}");
            Console.WriteLine($"Department: {employee.Department}");
            Console.WriteLine($"Job Title: {employee.JobTitle}");
            Console.WriteLine($"Salary: {employee.Salary:C}");
            Console.WriteLine($"Date Added: {employee.DateAdded}");
        }

        // Displays a shorter list used for update, raise, and delete actions.
        private void DisplayEmployeeSummary()
        {
            Console.WriteLine("\n--- Current Employees ---");

            foreach (Employee employee in employees)
            {
                Console.WriteLine($"ID: {employee.EmployeeId} | {employee.FirstName} {employee.LastName} | {employee.Department} | {employee.JobTitle}");
            }
        }
    }
}