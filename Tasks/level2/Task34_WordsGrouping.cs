using C_sharp_practicum.Common;

using System;
using System.Collections.Generic;
using System.Linq;

namespace C_sharp_practicum.Tasks.Level2
{
    public class Task34_WordsGrouping : ITask
    {
        public string Title => "LINQ: группировка слов";
        public string Description => "Сгруппировать слова по первой букве и отсортировать.";
        public string[] Requirements => new[] { "GroupBy(w => w[0])", "Сортировка групп и слов внутри" };

        public void Run()
        {
            List<string> words = new List<string>
            {
                "яблоко", "арбуз", "банан", "апельсин",
                "брусника", "вишня", "ягода", "абрикос",
                "ананас", "виноград", "баклажан"
            };

            // Группируем по первой букве, сортируем группы по ключу (букве)
            var grouped = words.GroupBy(w => w[0])
                               .OrderBy(g => g.Key);

            foreach (var group in grouped)
            {
                // Внутри группы сортируем слова по алфавиту
                var sortedWords = group.OrderBy(w => w);
                Console.WriteLine($"{group.Key}: {string.Join(", ", sortedWords)}");
            }
        }
    }
}