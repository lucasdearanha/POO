using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using LambdaEmployees.Entities;

namespace LambdaEmployees
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var employees = new List<Employee>();

            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();
            Console.Write("Salary: ");
            double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            using (var sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] data = sr.ReadLine().Split(',');
                    string name = data[0];
                    string email = data[1];
                    double salaryEmp = double.Parse(data[2], CultureInfo.InvariantCulture);
                    employees.Add(new Employee(name, email, salaryEmp));
                }
            }

            var emails = employees.Where(emp => emp.Salary > salary)
                .OrderBy(emp => emp.Email)
                .Select(emp => emp.Email).ToList();

            Console.WriteLine($"Email of people whose salary is more than {salary.ToString("F2", CultureInfo.InvariantCulture)}:");
            emails.ForEach(Console.WriteLine);

            var sum = employees.Where(emp => emp.Name[0] == 'M')
                .Select(emp => emp.Salary)
                .Aggregate(0.0, (x, y) => x + y);
            Console.WriteLine($"Sum of salary of people whose name starts with letter 'M': {sum.ToString("F2", CultureInfo.InvariantCulture)}");
        }
    }
}
