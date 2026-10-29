using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_sharp_practicum.Common;

namespace C_sharp_practicum.Tasks.Level1

{
    /// <summary>Задание 8 — FizzBuzz 1–100.</summary>
    public class Task08_FizzBuzz : ITask
    {
        /// <inheritdoc/>
        public string Title => "FizzBuzz 1–100";

        /// <inheritdoc/>
        public string Description => "Числа 1..100: кратные 3 → Fizz, 5 → Buzz, 15 → FizzBuzz.";

        /// <inheritdoc/>
        public string[] Requirements => new[]
        {
            "Кратно 3 → Fizz",
            "Кратно 5 → Buzz",
            "Кратно 15 → FizzBuzz",
            "Порядок проверок: сначала 15, потом 3 и 5"
        };

        /// <inheritdoc/>
        public void Run()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 15 == 0)
                    Console.WriteLine("FizzBuzz");
                else if (i % 3 == 0)
                    Console.WriteLine("Fizz");
                else if (i % 5 == 0)
                    Console.WriteLine("Buzz");
                else
                    Console.WriteLine(i);
            }
        }
    }
}