using C_sharp_practicum.Common;

using System;
using System.Collections.Generic;

namespace C_sharp_practicum.Tasks.Level2
{
    public class Task27_StudentsSorting : ITask
    {
        public string Title => "IComparable / IComparer для Student";
        public string Description => "Сортировка студентов по разным критериям.";
        public string[] Requirements => new[] { "IComparable<Student>", "IComparer<Student>" };

        public void Run()
        {
            List<Student> students = new List<Student>
            {
                new Student { Name = "Анна", AverageGrade = 4.5 },
                new Student { Name = "Иван", AverageGrade = 3.8 },
                new Student { Name = "Мария", AverageGrade = 4.9 },
                new Student { Name = "Петр", AverageGrade = 4.1 }
            };

            Console.WriteLine("По среднему баллу (убывание):");
            students.Sort(); // IComparable
            foreach (var s in students) Console.WriteLine($"{s.Name}: {s.AverageGrade}");

            Console.WriteLine("\nПо имени:");
            students.Sort(new ByNameComparer()); // IComparer
            foreach (var s in students) Console.WriteLine($"{s.Name}: {s.AverageGrade}");
        }
    }

    public class Student : IComparable<Student>
    {
        public string Name { get; set; }
        public double AverageGrade { get; set; }

        public int CompareTo(Student other)
        {
            // По убыванию балла
            return other.AverageGrade.CompareTo(this.AverageGrade);
        }
    }

    public class ByNameComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
        }
    }
}