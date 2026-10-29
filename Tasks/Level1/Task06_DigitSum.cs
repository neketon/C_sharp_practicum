using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_sharp_practicum.Common;

namespace C_sharp_practicum.Tasks.Level1

{
    /// <summary>Задание 6 — сумма цифр двумя способами.</summary>
    public class Task06_DigitSum : ITask
    {
        /// <inheritdoc/>
        public string Title => "Сумма цифр числа";

        /// <inheritdoc/>
        public string Description => "Найти сумму цифр числа: через строку и арифметикой.";

        /// <inheritdoc/>
        public string[] Requirements => new[]
        {
            "Способ 1: число → ToString → int.Parse каждой цифры",
            "Способ 2: while (n > 0) { sum += n % 10; n /= 10; }",
            "Оба метода отдельно",
            "Отрицательные числа — по модулю"
        };

        /// <inheritdoc/>
        public void Run()
        {
            Console.Write("Введите число: ");
            if (!int.TryParse(Console.ReadLine(), out int n))
            {
                Console.WriteLine("Некорректный ввод");
                return;
            }

            Console.WriteLine($"Способ 1 (строка): {SumByString(n)}");
            Console.WriteLine($"Способ 2 (арифметика): {SumByMath(n)}");
        }

        private int SumByString(int n)
        {
            string s = Math.Abs(n).ToString();
            int sum = 0;
            for (int i = 0; i < s.Length; i++)
                sum += int.Parse(s[i].ToString());
            return sum;
        }

        private int SumByMath(int n)
        {
            n = Math.Abs(n);
            int sum = 0;
            while (n > 0)
            {
                sum += n % 10;
                n /= 10;
            }
            return sum;
        }
    }
}
