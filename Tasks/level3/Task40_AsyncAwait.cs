using C_sharp_practicum.Common;

using System;
using System.Threading.Tasks;

namespace C_sharp_practicum.Tasks.Level3
{
    public class Task40_AsyncAwait : ITask
    {
        public string Title => "async/await + исключения";
        public string Description => "Асинхронное скачивание с обработкой ошибок.";
        public string[] Requirements => new[] { "async Task", "Task.Delay", "try/catch" };

        public void Run()
        {
            // Синхронно вызываем асинхронный код, чтобы вписаться в интерфейс ITask
            RunAsync().GetAwaiter().GetResult();
        }

        private async Task RunAsync()
        {
            try
            {
                string result = await DownloadAsync("http://example.com");
                Console.WriteLine("Успех: " + result);

                Console.WriteLine("Пробуем пустую ссылку...");
                await DownloadAsync("");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка (поймана): {ex.Message}");
            }
        }

        private async Task<string> DownloadAsync(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("URL не может быть пустым");

            await Task.Delay(1000); // Эмуляция задержки
            return $"Данные с {url}";
        }
    }
}