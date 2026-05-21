using System;

namespace EmployeeManagementSystem
{
    // This class represents ONE employee record.
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Department { get; set; }

        public string JobTitle { get; set; }

        public decimal Salary { get; set; }

        public DateTime DateAdded { get; set; }

        // Constructor used when creating a new employee.
        public Employee(int employeeId, string firstName, string lastName, string department, string jobTitle, decimal salary)
        {
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
            Department = department;
            JobTitle = jobTitle;
            Salary = salary;
            DateAdded = DateTime.Now;
        }
    }
}