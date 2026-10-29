using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_sharp_practicum.Common;

namespace C_sharp_practicum.Tasks.Level1
{

    /// <summary>Задание 9 — min/max/sum/avg без LINQ.</summary>
    public class Task09_ArrayStats : ITask
    {
        /// <inheritdoc/>
        public string Title => "Массивы: min/max/sum/avg";

        /// <inheritdoc/>
        public string Description => "Для массива из 20 случайных чисел найти min, max, сумму и среднее.";

        /// <inheritdoc/>
        public string[] Requirements => new[]
        {
            "Массив случайных чисел 1–100, размер 20",
            "Без LINQ (Min/Max/Sum/Average запрещены)",
            "4 отдельных метода",
            "Пустой массив не должен ронять программу"
        };

        /// <inheritdoc/>
        public void Run()
        {
            int[] arr = new int[20];
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
                arr[i] = rnd.Next(1, 101);

            Console.WriteLine("Массив: " + string.Join(", ", arr));

            if (arr.Length == 0)
            {
                Console.WriteLine("Массив пуст");
                return;
            }

            Console.WriteLine($"Min = {FindMin(arr)}");
            Console.WriteLine($"Max = {FindMax(arr)}");
            Console.WriteLine($"Sum = {FindSum(arr)}");
            Console.WriteLine($"Avg = {FindAvg(arr):F2}");
        }

        private int FindMin(int[] a)
        {
            int min = a[0];
            for (int i = 1; i < a.Length; i++)
                if (a[i] < min) min = a[i];
            return min;
        }

        private int FindMax(int[] a)
        {
            int max = a[0];
            for (int i = 1; i < a.Length; i++)
                if (a[i] > max) max = a[i];
            return max;
        }

        private int FindSum(int[] a)
        {
            int sum = 0;
            for (int i = 0; i < a.Length; i++)
                sum += a[i];
            return sum;
        }

        private double FindAvg(int[] a)
        {
            return (double)FindSum(a) / a.Length;
        }
    }
}