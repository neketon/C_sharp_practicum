using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_sharp_practicum.Common;

namespace C_sharp_practicum.Tasks.Level1
{

    /// <summary>Задание 14 — возраст по дате рождения.</summary>
    public class Task14_Age : ITask
    {
        /// <inheritdoc/>
        public string Title => "Возраст по дате рождения";

        /// <inheritdoc/>
        public string Description => "Вычислить точный возраст в годах, месяцах и днях.";

        /// <inheritdoc/>
        public string[] Requirements => new[]
        {
            "Ввод через DateTime.TryParse",
            "Учесть, что ДР в этом году мог не наступить",
            "Вывести «X лет, Y месяцев, Z дней»",
            "Некорректная дата — сообщение, не падать"
        };

        /// <inheritdoc/>
        public void Run()
        {
            Console.Write("Введите дату рождения (например 15.06.2000): ");
            string input = Console.ReadLine();

            if (!DateTime.TryParse(input, out DateTime birth))
            {
                Console.WriteLine("Некорректная дата");
                return;
            }

            DateTime today = DateTime.Today;
            if (birth > today)
            {
                Console.WriteLine("Дата рождения в будущем");
                return;
            }

            int years = today.Year - birth.Year;
            int months = today.Month - birth.Month;
            int days = today.Day - birth.Day;

            if (days < 0)
            {
                months--;
                DateTime prevMonth = today.AddMonths(-1);
                days += DateTime.DaysInMonth(prevMonth.Year, prevMonth.Month);
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            Console.WriteLine($"{years} лет, {months} месяцев, {days} дней");
        }
    }
}