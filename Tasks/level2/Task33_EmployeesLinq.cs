using C_sharp_practicum.Common;

using System;
using System.Collections.Generic;
using System.Linq;

namespace C_sharp_practicum.Tasks.Level2
{
    public class Task33_EmployeesLinq : ITask
    {
        public string Title => "LINQ: сотрудники";
        public string Description => "Запросы к списку сотрудников.";
        public string[] Requirements => new[] { "Top-3 по зарплате", "Средняя по отделу", "Старше 30" };

        public void Run()
        {
            var employees = new List<Employee>
            {
                new Employee { Name = "Иван", Age = 25, Salary = 50000, Department = "IT" },
                new Employee { Name = "Мария", Age = 32, Salary = 70000, Department = "IT" },
                new Employee { Name = "Петр", Age = 40, Salary = 60000, Department = "HR" },
                new Employee { Name = "Анна", Age = 28, Salary = 55000, Department = "HR" },
                new Employee { Name = "Олег", Age = 35, Salary = 80000, Department = "IT" }
            };

            Console.WriteLine("Топ-3 по зарплате:");
            var top3 = employees.OrderByDescending(e => e.Salary).Take(3);
            foreach (var e in top3) Console.WriteLine($"{e.Name}: {e.Salary}");

            Console.WriteLine("\nСредняя зарплата по отделам:");
            var avgByDept = employees.GroupBy(e => e.Department)
                                     .Select(g => new { Dept = g.Key, Avg = g.Average(e => e.Salary) });
            foreach (var item in avgByDept) Console.WriteLine($"{item.Dept}: {item.Avg:F2}");

            Console.WriteLine("\nСотрудники старше 30:");
            var olderThan30 = employees.Where(e => e.Age > 30);
            foreach (var e in olderThan30) Console.WriteLine($"{e.Name} ({e.Age} лет)");
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public string Department { get; set; }
    }
}