using C_sharp_practicum.Common;
using C_sharp_practicum.Tasks.Level1;
using C_sharp_practicum.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_practicum.Menu
{
    /// <summary>Главное меню практикума.</summary>
    public static class MenuRunner
    {
        /// <summary>Запускает главное меню.</summary>
        public static void Run()
        {
            List<ITask> level1 = new List<ITask>
            {
                new Task01_HelloWorld(),
                /* new Task02_Primitives(),
                new Task03_Calculator(),
                new Task04_EvenOdd(),
                new Task05_MultiplicationTable(),
                new Task06_DigitSum(),
                new Task07_ReverseString(),
                new Task08_FizzBuzz(),
                new Task09_ArrayStats(),
                new Task10_Sorting(),
                new Task11_MatrixDiagonal(),
                new Task12_Palindrome(),
                new Task13_WordCount(),
                new Task14_Age(),
                new Task15_GitBasics() */
            };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Практикум по C# ===");
                Console.WriteLine("1. Уровень 1 — Базовый (задания 1–15)");
                Console.WriteLine("2. Уровень 2 — Средний (задания 16–35)");
                Console.WriteLine("3. Уровень 3 — Продвинутый (задания 36–50)");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите уровень: ");

                string input = Console.ReadLine();
                if (input == "0" || input == "q")
                    return;

                switch (input)
                {
                    case "1":
                        new LevelMenu("Уровень 1: Базовый", level1).Run();
                        break;
                    case "2":
                    case "3":
                        Console.WriteLine("Уровень пока не готов. Нажмите Enter...");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Нажмите Enter...");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}