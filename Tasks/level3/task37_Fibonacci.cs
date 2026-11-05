using C_sharp_practicum.Common;

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace C_sharp_practicum.Tasks.Level3
{
    public class Task37_Fibonacci : ITask
    {
        public string Title => "Мемоизация Фибоначчи";
        public string Description => "Сравнение рекурсивной и мемоизированной версии Фибоначчи.";
        public string[] Requirements => new[] { "Обычная рекурсия", "Dictionary<int, long>", "Замер Stopwatch" };

        public void Run()
        {
            int n = 35;
            Stopwatch sw = new Stopwatch();

            sw.Start();
            long normal = FibNormal(n);
            sw.Stop();
            Console.WriteLine($"Обычная рекурсия (N={n}): {normal} ({sw.ElapsedMilliseconds} мс)");

            sw.Restart();
            long memo = FibMemo(n, new Dictionary<int, long>());
            sw.Stop();
            Console.WriteLine($"Мемоизация (N={n}):      {memo} ({sw.ElapsedMilliseconds} мс)");
        }

        private long FibNormal(int n)
        {
            if (n <= 1) return n;
            return FibNormal(n - 1) + FibNormal(n - 2);
        }

        private long FibMemo(int n, Dictionary<int, long> memo)
        {
            if (n <= 1) return n;
            if (memo.ContainsKey(n)) return memo[n];

            long result = FibMemo(n - 1, memo) + FibMemo(n - 2, memo);
            memo[n] = result;
            return result;
        }
    }
}