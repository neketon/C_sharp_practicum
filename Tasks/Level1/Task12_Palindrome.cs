using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_sharp_practicum.Common;

namespace C_sharp_practicum.Tasks.Level1
{

    /// <summary>Задание 12 — палиндром.</summary>
    public class Task12_Palindrome : ITask
    {
        /// <inheritdoc/>
        public string Title => "Палиндром (без регистра/пробелов)";

        /// <inheritdoc/>
        public string Description => "Проверить, является ли строка палиндромом с игнорированием регистра и знаков.";

        /// <inheritdoc/>
        public string[] Requirements => new[]
        {
            "Игнорировать регистр (ToLower)",
            "Игнорировать пробелы и пунктуацию",
            "Без LINQ Reverse",
            "Пустая строка и один символ — палиндром"
        };

        /// <inheritdoc/>
        public void Run()
        {
            Console.Write("Введите строку: ");
            string input = Console.ReadLine() ?? "";
            Console.WriteLine($"Палиндром: {IsPalindrome(input)}");
        }

        private bool IsPalindrome(string input)
        {
            string cleaned = "";
            foreach (char ch in input.ToLower())
            {
                if (char.IsLetterOrDigit(ch))
                    cleaned += ch;
            }

            for (int i = 0; i < cleaned.Length / 2; i++)
            {
                if (cleaned[i] != cleaned[cleaned.Length - 1 - i])
                    return false;
            }
            return true;
        }
    }
}