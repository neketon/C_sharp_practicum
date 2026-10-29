using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_sharp_practicum.Common;

namespace C_sharp_practicum.Tasks.Level1

{
    /// <summary>Задание 7 — реверс строки без LINQ.</summary>
    public class Task07_ReverseString : ITask
    {
        /// <inheritdoc/>
        public string Title => "Реверс строки без LINQ";

        /// <inheritdoc/>
        public string Description => "Перевернуть строку через цикл, без Array.Reverse и LINQ.";

        /// <inheritdoc/>
        public string[] Requirements => new[]
        {
            "Без Array.Reverse и LINQ",
            "Цикл for от конца к началу",
            "Пустая строка и один символ — корректно"
        };

        /// <inheritdoc/>
        public void Run()
        {
            Console.Write("Введите строку: ");
            string s = Console.ReadLine() ?? "";
            Console.WriteLine($"Результат: \"{Reverse(s)}\"");
        }

        private string Reverse(string s)
        {
            string result = "";
            for (int i = s.Length - 1; i >= 0; i--)
                result += s[i];
            return result;
        }
    }
}