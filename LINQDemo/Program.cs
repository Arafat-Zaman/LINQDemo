using System;
using System.Linq;
using System.Collections.Generic;

namespace LINQDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Step 1: Define a data source (List of Employees)
            List<Employee> employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Alice", Department = "HR", Age = 28, Salary = 50000 },
                new Employee { Id = 2, Name = "Bob", Department = "IT", Age = 35, Salary = 70000 },
                new Employee { Id = 3, Name = "Charlie", Department = "IT", Age = 25, Salary = 60000 },
                new Employee { Id = 4, Name = "David", Department = "Finance", Age = 42, Salary = 80000 },
                new Employee { Id = 5, Name = "Eve", Department = "HR", Age = 30, Salary = 55000 }
            };

            // Step 2: Use LINQ to filter, sort, and project data
            var filteredEmployees = from emp in employees
                                    where emp.Department == "IT" && emp.Age > 30
                                    orderby emp.Salary descending
                                    select new { emp.Name, emp.Salary, emp.Age };

            // Step 3: Display the results
            Console.WriteLine("IT Employees older than 30, sorted by Salary (Descending):");
            foreach (var emp in filteredEmployees)
            {
                Console.WriteLine($"Name: {emp.Name}, Age: {emp.Age}, Salary: {emp.Salary}");
            }

            // Step 4: Use LINQ with method syntax
            var hrEmployees = employees.Where(e => e.Department == "HR")
                                       .OrderBy(e => e.Age)
                                       .Select(e => new { e.Name, e.Age });

            Console.WriteLine("\nHR Employees sorted by Age (Ascending):");
            foreach (var emp in hrEmployees)
            {
                Console.WriteLine($"Name: {emp.Name}, Age: {emp.Age}");
            }
        }
    }

    // Employee class definition
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
    }
}
