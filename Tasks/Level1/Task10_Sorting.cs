using C_sharp_practicum.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_practicum.Tasks.Level1

{
    /// <summary>Задание 10 — пузырёк и вставки.</summary>
    public class Task10_Sorting : ITask
    {
        /// <inheritdoc/>
        public string Title => "Сортировка пузырьком + вставками";

        /// <inheritdoc/>
        public string Description => "Отсортировать массив двумя алгоритмами и замерить время на 10 000 элементов.";

        /// <inheritdoc/>
        public string[] Requirements => new[]
        {
            "BubbleSort и InsertionSort отдельными методами",
            "Без LINQ и Array.Sort",
            "Stopwatch на массиве 10 000 элементов",
            "Вывести оба времени"
        };

        /// <inheritdoc/>
        public void Run()
        {
            int size = 10000;
            int[] original = new int[size];
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
                original[i] = rnd.Next(0, 100000);

            int[] a = (int[])original.Clone();
            int[] b = (int[])original.Clone();

            Stopwatch sw = Stopwatch.StartNew();
            BubbleSort(a);
            sw.Stop();
            Console.WriteLine($"BubbleSort:    {sw.ElapsedMilliseconds} мс");

            sw.Restart();
            InsertionSort(b);
            sw.Stop();
            Console.WriteLine($"InsertionSort: {sw.ElapsedMilliseconds} мс");

            Console.WriteLine($"Массивы отсортированы одинаково: {AreEqual(a, b)}");
        }

        private void BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
                for (int j = 0; j < arr.Length - 1 - i; j++)
                    if (arr[j] > arr[j + 1])
                    {
                        int t = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = t;
                    }
        }

        private void InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int key = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }

        private bool AreEqual(int[] a, int[] b)
        {
            if (a.Length != b.Length) return false;
            for (int i = 0; i < a.Length; i++)
                if (a[i] != b[i]) return false;
            return true;
        }
    }
}