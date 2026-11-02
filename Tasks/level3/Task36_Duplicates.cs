using C_sharp_practicum.Common;

using System;
using System.Collections.Generic;
using System.Linq;

namespace C_sharp_practicum.Tasks.Level3
{
    public class Task36_Duplicates : ITask
    {
        public string Title => "Дубликаты вd List";
        public string Description => "Поиск дубликатов через HashSet и LINQ GroupBy.";
        public string[] Requirements => new[] { "HashSet", "GroupBy", "Оба метода отдельно" };

        public void Run()
        {
            List<int> numbers = new List<int> { 1, 3, 5, 3, 7, 1, 9, 5, 10 };

            Console.WriteLine("Список: " + string.Join(", ", numbers));
            Console.WriteLine("Дубликаты (HashSet): " + string.Join(", ", FindDuplicatesHashSet(numbers)));
            Console.WriteLine("Дубликаты (LINQ):    " + string.Join(", ", FindDuplicatesLinq(numbers)));
        }

        private List<int> FindDuplicatesHashSet(List<int> list)
        {
            HashSet<int> seen = new HashSet<int>();
            HashSet<int> duplicates = new HashSet<int>();

            foreach (int num in list)
            {
                if (!seen.Add(num))
                    duplicates.Add(num);
            }
            return duplicates.ToList();
        }

        private List<int> FindDuplicatesLinq(List<int> list)
        {
            return list.GroupBy(x => x)
                       .Where(g => g.Count() > 1)
                       .Select(g => g.Key)
                       .ToList();
        }
    }
}