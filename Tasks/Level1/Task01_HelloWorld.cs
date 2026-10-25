using System;
using C_sharp_practicum.Common;


namespace C_sharp_practicum.Tasks.Level1
{
    /// <summary>Задание 1 — Hello, World + дата.</summary>
    public class Task01_HelloWorld : ITask
    {
        /// <inheritdoc/>
        public string Title => "Hello, World + текущая дата";

        /// <inheritdoc/>
        public string Description => "Вывести приветствие и текущую дату.";

        /// <inheritdoc/>
        public string[] Requirements => new[]
        {
            "Использовать Console.WriteLine",
            "Дату получить через DateTime.Now, формат dd.MM.yyyy",
            "Вывести две строки: приветствие и дату"
        };

        /// <inheritdoc/>
        public void Run()
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine(DateTime.Now.ToString("dd.MM.yyyy"));
        }
    }
}