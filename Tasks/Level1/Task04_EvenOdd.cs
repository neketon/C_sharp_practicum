using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_sharp_practicum.Common;

namespace C_sharp_practicum.Tasks.Level1

{
    /// <summary>Задание 4 — чётность двумя способами.</summary>
    public class Task04_EvenOdd : ITask
    {
        /// <inheritdoc/>
        public string Title => "Чётность числа (два способа)";

        /// <inheritdoc/>
        public string Description => "Определить, чётное ли введённое число, двумя способами.";

        /// <inheritdoc/>
        public string[] Requirements => new[]
        {
            "Способ 1: через % 2 == 0",
            "Способ 2: через тернарный оператор ?:",
            "Оба способа — отдельными методами"
        };

        /// <inheritdoc/>
        public void Run()
        {
            Console.Write("Введите целое число: ");
            if (!int.TryParse(Console.ReadLine(), out int n))
            {
                Console.WriteLine("Некорректный ввод");
                return;
            }

            Console.WriteLine($"Способ 1 (%): {IsEvenMod(n)}");
            Console.WriteLine($"Способ 2 (?:): {IsEvenTernary(n)}");
        }

        private bool IsEvenMod(int n)
        {
            return n % 2 == 0;
        }

        private bool IsEvenTernary(int n)
        {
            return n % 2 == 0 ? true : false;
        }
    }
}