using C_sharp_practicum.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace C_sharp_practicum.Tasks.Level3
{
    public class Task38_ListVsLinkedList : ITask
    {
        public string Title => "List vs LinkedList";
        public string Description => "Сравнение вставки в середину.";
        public string[] Requirements => new[] { "100 000 элементов", "1000 вставок", "Stopwatch" };

        public void Run()
        {
            int size = 100000;
            int inserts = 1000;
            Stopwatch sw = new Stopwatch();

            List<int> list = new List<int>(new int[size]);
            LinkedList<int> linked = new LinkedList<int>(new int[size]);

            sw.Start();
            for (int i = 0; i < inserts; i++)
                list.Insert(size / 2, i);
            sw.Stop();
            Console.WriteLine($"List вставка:       {sw.ElapsedMilliseconds} мс");

            sw.Restart();
            // Быстрый поиск середины в LinkedList (иначе он будет искать её 50 000 шагов каждый раз)
            LinkedListNode<int> middle = linked.First;
            for (int i = 0; i < size / 2; i++) middle = middle.Next;

            for (int i = 0; i < inserts; i++)
                linked.AddBefore(middle, i);
            sw.Stop();
            Console.WriteLine($"LinkedList вставка: {sw.ElapsedMilliseconds} мс");

            // List быстрее, так как вставка в середину массива использует Array.Copy (очень быстро на уровне памяти),
            // а LinkedList тратит время на аллокацию памяти под каждый новый узел.
        }
    }
}