using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_sharp_practicum.Common;

namespace C_sharp_practicum.Tasks.Level1
{

    /// <summary>Задание 13 — счётчик вхождений слов.</summary>
    public class Task13_WordCount : ITask
    {
        /// <inheritdoc/>
        public string Title => "Счётчик вхождений слов (Dictionary)";

        /// <inheritdoc/>
        public string Description => "Посчитать, сколько раз каждое слово встречается в тексте.";

        /// <inheritdoc/>
        public string[] Requirements => new[]
        {
            "Использовать Dictionary<string,int>",
            "Разбить по пробелам и пунктуации",
            "Слова к нижнему регистру",
            "Сортировка по убыванию количества"
        };

        /// <inheritdoc/>
        public void Run()
        {
            Console.WriteLine("Введите текст (одной строкой):");
            string text = Console.ReadLine() ?? "";

            char[] separators = { ' ', '.', ',', '!', '?', ';', ':', '-', '\t' };
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (string w in words)
            {
                string key = w.ToLower();
                if (dict.ContainsKey(key))
                    dict[key]++;
                else
                    dict[key] = 1;
            }

            foreach (var pair in dict.OrderByDescending(p => p.Value))
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
        }
    }
}