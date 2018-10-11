using System;

namespace Employees
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int n = 16;

            Employee[] employees = new Employee[n];

            for (int i = 0; i < n / 2; i++)
            {
                employees[i] = new MREmployee($"Имя_{i}", i, $"должность_{i}", rnd.Next(1000,10000));
                employees[i + n / 2] = new HREmployee($"Имя_{i + n / 2}", i + n / 2, $"должность_{i + n / 2}", rnd.Next(1000,10000));
            }

            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }

            Console.WriteLine();

            Array.Sort(employees);

            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }

            Console.ReadKey();
        }
    }
}
