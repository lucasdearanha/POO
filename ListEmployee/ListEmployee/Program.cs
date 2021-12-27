using System;
using System.Collections.Generic;
using System.Globalization;
using ListEmployee.Entities;

namespace ListEmployee
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var employees = new List<Employee>();

            Console.Write("How many employees will be registered? ");
            int register = int.Parse(Console.ReadLine());

            for (int i = 0; i < register; i++)
            {
                Console.WriteLine($"Employee #{i+1}:");
                Console.Write("Id: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Salary: ");
                decimal salary = decimal.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                employees.Add(new Employee(id, name, salary));
                Console.WriteLine();
            }

            Console.WriteLine();

            Console.Write("Enter the employee id that will have salary increase: ");
            int idForSearch = int.Parse(Console.ReadLine());
        
            var employeeFound = employees.Find(x => x.Id == idForSearch);

            if (employeeFound != null)
            {
                Console.Write("Enter the percentage: ");
                decimal percentage = decimal.Parse(Console.ReadLine());
                employeeFound.IncreaseSalary(percentage);
            }
            else
            {
                Console.WriteLine("Do not exist any employee with that Id!");
            }

            Console.WriteLine();
            Console.WriteLine("Updated list of employees: ");
            employees.ForEach(Console.WriteLine);
        }
    }
}
