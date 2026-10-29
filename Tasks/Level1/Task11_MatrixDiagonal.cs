using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_sharp_practicum.Common;



namespace CSharpPracticum.Tasks.Level1
{
    /// <summary>Задание 11 — диагональ матрицы.</summary>
    public class Task11_MatrixDiagonal : ITask
    {
        /// <inheritdoc/>
        public string Title => "Диагональ матрицы N×N";

        /// <inheritdoc/>
        public string Description => "Найти сумму элементов главной диагонали матрицы N×N.";

        /// <inheritdoc/>
        public string[] Requirements => new[]
        {
            "N вводится (минимум 2)",
            "Матрица случайная",
            "Сумма без LINQ, в одном for",
            "Вывести матрицу и сумму"
        };

        /// <inheritdoc/>
        public void Run()
        {
            Console.Write("Введите N (>=2): ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n < 2)
            {
                Console.WriteLine("Некорректный размер");
                return;
            }

            int[,] m = new int[n, n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    m[i, j] = rnd.Next(1, 10);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write($"{m[i, j],4}");
                Console.WriteLine();
            }

            int sum = 0;
            for (int i = 0; i < n; i++)
                sum += m[i, i];

            Console.WriteLine($"Сумма главной диагонали: {sum}");
        }
    }
}