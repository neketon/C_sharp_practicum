using C_sharp_practicum.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace C_sharp_practicum.Tasks.Level3
{
    public class Task41_ParallelTasks : ITask
    {
        public string Title => "Task.WhenAll — 10 задач";
        public string Description => "Сравнение последовательного и параллельного выполнения.";
        public string[] Requirements => new[] { "Task.Delay(500)", "Task.WhenAll", "Stopwatch" };

        public void Run()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        private async Task RunAsync()
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();
            for (int i = 1; i <= 10; i++)
                await WorkAsync(i);
            sw.Stop();
            Console.WriteLine($"Последовательно: {sw.ElapsedMilliseconds} мс");

            sw.Restart();
            List<Task<int>> tasks = new List<Task<int>>();
            for (int i = 1; i <= 10; i++)
                tasks.Add(WorkAsync(i));

            int[] results = await Task.WhenAll(tasks);
            sw.Stop();
            Console.WriteLine($"Параллельно (WhenAll): {sw.ElapsedMilliseconds} мс");
        }

        private async Task<int> WorkAsync(int id)
        {
            await Task.Delay(500);
            return id;
        }
    }
}