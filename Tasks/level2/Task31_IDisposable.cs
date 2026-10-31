using C_sharp_practicum.Common;

using System;
using System.IO;

namespace C_sharp_practicum.Tasks.Level2
{
    public class Task31_IDisposable : ITask
    {
        public string Title => "IDisposable + using";
        public string Description => "Работа с файлом через IDisposable.";
        public string[] Requirements => new[] { "FileWriter", "using" };

        public void Run()
        {
            string path = "test_file.txt";

            // Классический using (с фигурными скобками)
            using (var writer1 = new FileWriter(path))
            {
                writer1.Write("Первая строка");
            } // Здесь файл автоматически закроется

            // Второй вариант записи (тоже с фигурными скобками, так как using var недоступен)
            using (var writer2 = new FileWriter(path))
            {
                writer2.Write("Вторая строка");
            }

            Console.WriteLine("Файл записан и успешно закрыт!");
        }
    }

    public class FileWriter : IDisposable
    {
        private StreamWriter _writer;
        private bool _disposed = false;

        public FileWriter(string path)
        {
            _writer = new StreamWriter(path, true); // true = дописывать в конец
        }

        public void Write(string text)
        {
            if (_disposed) throw new ObjectDisposedException(nameof(FileWriter));
            _writer.WriteLine(text);
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _writer?.Dispose();
                _disposed = true;
            }
        }
    }
}