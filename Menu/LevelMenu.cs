using C_sharp_practicum.Common;

using System;
using System.Collections.Generic;

namespace C_sharp_practicum.Menu
{
    /// <summary>Меню одного уровня.</summary>
    public class LevelMenu
    {
        private readonly string name;
        private readonly List<ITask> tasks;

        /// <summary>Создаёт меню уровня.</summary>
        public LevelMenu(string name, List<ITask> tasks)
        {
            this.name = name;
            this.tasks = tasks;
        }

        /// <summary>Запускает цикл меню уровня.</summary>
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"--- {name} ---");
                for (int i = 0; i < tasks.Count; i++)
                    Console.WriteLine($"{i + 1}. {tasks[i].Title}");
                Console.WriteLine("0. Назад");
                Console.Write("Выберите задание: ");

                string input = Console.ReadLine();
                if (input == "0" || input == "q")
                    return;

                if (!int.TryParse(input, out int num) || num < 1 || num > tasks.Count)
                {
                    Console.WriteLine("Нет такого задания. Нажмите Enter...");
                    Console.ReadLine();
                    continue;
                }

                RunTask(tasks[num - 1], num);
            }
        }

        private void RunTask(ITask task, int number)
        {
            Console.Clear();
            Console.WriteLine("==================================================");
            Console.WriteLine($"Задание {number}. {task.Title}");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Описание:");
            Console.WriteLine("  " + task.Description);
            Console.WriteLine();
            Console.WriteLine("Требования:");
            foreach (string r in task.Requirements)
                Console.WriteLine("  - " + r);
            Console.WriteLine("--------------------------------------------------");

            try
            {
                task.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            ConsoleHelper.Pause();
        }
    }
}