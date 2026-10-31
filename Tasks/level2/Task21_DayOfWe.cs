using C_sharp_practicum.Common;

using System;

namespace C_sharp_practicum.Tasks.Level2
{
    public class Task21_DayOfWeek : ITask
    {
        public string Title => "enum дни недели";
        public string Description => "Определить тип дня (выходной/будний) и название.";
        public string[] Requirements => new[] { "enum DayOfWeek", "IsWeekend", "GetRussianName" };

        public enum DayOfWeek { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }

        public void Run()
        {
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                Console.WriteLine($"{day}: {GetRussianName(day)} - Выходной? {IsWeekend(day)}");
            }
        }

        private bool IsWeekend(DayOfWeek day)
        {
            return day == DayOfWeek.Saturday || day == DayOfWeek.Sunday;
        }

        private string GetRussianName(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Monday: return "Понедельник";
                case DayOfWeek.Tuesday: return "Вторник";
                case DayOfWeek.Wednesday: return "Среда";
                case DayOfWeek.Thursday: return "Четверг";
                case DayOfWeek.Friday: return "Пятница";
                case DayOfWeek.Saturday: return "Суббота";
                case DayOfWeek.Sunday: return "Воскресенье";
                default: return "Неизвестно";
            }
        }
    }
}