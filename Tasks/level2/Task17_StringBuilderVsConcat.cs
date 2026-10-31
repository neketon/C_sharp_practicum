using C_sharp_practicum.Common;

using System;
using System.Diagnostics;
using System.Text;

namespace C_sharp_practicum.Tasks.Level2
{
    public class Task17_StringBuilderVsConcat : ITask
    {
        public string Title => "StringBuilder vs конкатенация";
        public string Description => "Сравнить производительность конкатенации через + и StringBuilder.";
        public string[] Requirements => new[] { "Собрать строку из 10 000 чисел", "Замерить Stopwatch" };

        public void Run()
        {
            int count = 10000;
            Stopwatch sw = new Stopwatch();

            sw.Start();
            string concatResult = "";
            for (int i = 0; i < count; i++)
                concatResult += i.ToString();
            sw.Stop();
            Console.WriteLine($"Конкатенация (+): {sw.ElapsedMilliseconds} мс");

            sw.Restart();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
                sb.Append(i);
            string sbResult = sb.ToString();
            sw.Stop();
            Console.WriteLine($"StringBuilder:    {sw.ElapsedMilliseconds} мс");

            Console.WriteLine($"Результаты равны: {concatResult == sbResult}");

            // StringBuilder быстрее, потому что строка в C# неизменяема (immutable).
            // При каждом += создается новый объект в памяти и копируются старые данные.
            // StringBuilder хранит буфер в памяти и просто дописывает в него данные без пересоздания.
        }
    }
}