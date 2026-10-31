using C_sharp_practicum.Common;

using System;

namespace C_sharp_practicum.Tasks.Level2
{
    public class Task18_TryParseVsTryCatch : ITask
    {
        public string Title => "TryParse vs try/catch";
        public string Description => "Сравнить два способа обработки некорректного ввода числа.";
        public string[] Requirements => new[] { "TryParse с out", "Parse внутри try/catch" };

        public void Run()
        {
            string[] inputs = { "123", "abc", "-50" };

            foreach (string input in inputs)
            {
                Console.WriteLine($"Ввод: \"{input}\"");
                Console.WriteLine($"TryParse: {ParseWithTryParse(input, out int res1)} (результат: {res1})");
                Console.WriteLine($"Try/Catch: {ParseWithTryCatch(input, out int res2)} (результат: {res2})");
                Console.WriteLine();
            }
        }

        private bool ParseWithTryParse(string input, out int result)
        {
            return int.TryParse(input, out result);
        }

        private bool ParseWithTryCatch(string input, out int result)
        {
            result = 0;
            try
            {
                result = int.Parse(input);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
            catch (OverflowException)
            {
                return false;
            }
        }
    }
}