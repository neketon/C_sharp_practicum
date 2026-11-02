using C_sharp_practicum.Common;
using System;
using System.Collections.Generic;

namespace C_sharp_practicum.Tasks.Level3
{
    public class Task39_YieldReturn : ITask
    {
        public string Title => "yield return — генератор чётных чисел";
        public string Description => "Ленивый генератор чётных чисел.";
        public string[] Requirements => new[] { "IEnumerable<int>", "yield return", "Показать ленивость" };

        public void Run()
        {
            Console.WriteLine("Начинаем обход:");
            foreach (var num in GetEvenNumbers(10))
            {
                Console.WriteLine($"Получено число: {num}");
            }
        }

        private IEnumerable<int> GetEvenNumbers(int max)
        {
            for (int i = 0; i <= max; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine($"  [Генератор сгенерировал {i}]"); // Доказывает ленивость
                    yield return i;
                }
            }
        }
    }
}