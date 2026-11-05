using C_sharp_practicum.Common;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace C_sharp_practicum.Tasks.Level3
{
    public class Task42_Cancellation : ITask
    {
        public string Title => "CancellationToken — отмена";
        public string Description => "Отмена долгой операции через 2 секунды.";
        public string[] Requirements => new[] { "CancellationTokenSource", "OperationCanceledException" };

        public void Run()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        private async Task RunAsync()
        {
            // Классический using с фигурными скобками (работает в C# 7.3)
            using (var cts = new CancellationTokenSource())
            {
                cts.CancelAfter(2000); // Отменить через 2 секунды

                try
                {
                    Console.WriteLine("Запуск операции...");
                    await LongOperationAsync(cts.Token);
                    Console.WriteLine("Операция завершена успешно.");
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Операция отменена!");
                }
            } // Здесь cts автоматически освободит ресурсы
        }

        private async Task LongOperationAsync(CancellationToken token)
        {
            for (int i = 0; i < 10; i++)
            {
                token.ThrowIfCancellationRequested();
                Console.WriteLine($"Шаг {i + 1} из 10...");
                await Task.Delay(500, token);
            }
        }
    }
}