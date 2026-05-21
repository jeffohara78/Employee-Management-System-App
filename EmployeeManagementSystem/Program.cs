/* Jeff O'Hara
 * 5-21-26
 * 
 * This console application is an employee management system that allows users to add, view, and manage employee records. 
 * It provides a simple interface for performing various operations related to employee data.
 * It would be a great app for an HR department or a small business looking to keep track of their employees.
 */

using System;

namespace EmployeeManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeManager manager = new EmployeeManager();

            bool running = true;

            while (running)
            {
                Console.WriteLine("\n================================");
                Console.WriteLine("   EMPLOYEE MANAGEMENT SYSTEM");
                Console.WriteLine("================================");
                Console.WriteLine("Choose an option by typing the number.");
                Console.WriteLine();
                Console.WriteLine("1. Add a new employee");
                Console.WriteLine("2. View all employees");
                Console.WriteLine("3. Search employees");
                Console.WriteLine("4. Update employee department or job title");
                Console.WriteLine("5. Give employee a raise");
                Console.WriteLine("6. Delete employee");
                Console.WriteLine("7. Exit");
                Console.Write("\nEnter your choice, such as 1 or 2: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    manager.AddEmployee();
                }
                else if (choice == "2")
                {
                    manager.ViewAllEmployees();
                }
                else if (choice == "3")
                {
                    manager.SearchEmployees();
                }
                else if (choice == "4")
                {
                    manager.UpdateEmployee();
                }
                else if (choice == "5")
                {
                    manager.GiveRaise();
                }
                else if (choice == "6")
                {
                    manager.DeleteEmployee();
                }
                else if (choice == "7")
                {
                    running = false;
                    Console.WriteLine("Exiting Employee Management System.");
                }
                else
                {
                    Console.WriteLine("Invalid option. Please type a number from 1 through 7.");
                }
            }
        }
    }
}