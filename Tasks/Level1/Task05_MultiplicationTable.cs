using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_sharp_practicum.Common;

namespace C_sharp_practicum.Tasks.Level1

{
    /// <summary>Задание 5 — таблица умножения 10×10.</summary>
    public class Task05_MultiplicationTable : ITask
    {
        /// <inheritdoc/>
        public string Title => "Таблица умножения 10×10";

        /// <inheritdoc/>
        public string Description => "Вывести таблицу умножения 10×10 ровными столбцами.";

        /// <inheritdoc/>
        public string[] Requirements => new[]
        {
            "Вложенные циклы for",
            "Выровненные столбцы",
            "Желательно с заголовками строк и столбцов"
        };

        /// <inheritdoc/>
        public void Run()
        {
            Console.Write("   ");
            for (int j = 1; j <= 10; j++)
                Console.Write($"{j,4}");
            Console.WriteLine();
            Console.WriteLine(new string('-', 44));

            for (int i = 1; i <= 10; i++)
            {
                Console.Write($"{i,2} ");
                for (int j = 1; j <= 10; j++)
                    Console.Write($"{i * j,4}");
                Console.WriteLine();
            }
        }
    }
}