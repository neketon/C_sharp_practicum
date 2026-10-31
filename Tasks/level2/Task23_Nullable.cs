using C_sharp_practicum.Common;

using System;
using System.Collections.Generic;

namespace C_sharp_practicum.Tasks.Level2
{
    public class Task23_Nullable : ITask
    {
        public string Title => "Nullable-типы, ??, ?.";
        public string Description => "Демонстрация работы с nullable типами.";
        public string[] Requirements => new[] { "int? FindValue", "??", "?." };

        private Dictionary<string, int> _data = new Dictionary<string, int> { { "one", 1 }, { "two", 2 } };

        public void Run()
        {
            int? val1 = FindValue("one");
            int? val2 = FindValue("three");

            Console.WriteLine($"val1 (one): {val1 ?? -1}"); // Использование ??
            Console.WriteLine($"val2 (three): {val2 ?? -1}");

            if (val2.HasValue)
                Console.WriteLine($"val2.Value: {val2.Value}");
            else
                Console.WriteLine("val2 не имеет значения (null)");

            // Демонстрация ?. на примере строки
            string text = null;
            int? length = text?.Length; // ?. (если text null, length будет null)
            Console.WriteLine($"Длина null-строки: {length ?? 0}");
        }

        private int? FindValue(string key)
        {
            if (_data.TryGetValue(key, out int val)) return val;
            return null;
        }
    }
}