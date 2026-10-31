using C_sharp_practicum.Common;
using System;

namespace C_sharp_practicum.Tasks.Level2
{
    public class Task32_Temperature : ITask
    {
        public string Title => "Свойства с валидацией (Temperature)";
        public string Description => "Класс Temperature с проверкой в set.";
        public string[] Requirements => new[] { "Валидация в set", "Вычисляемое Fahrenheit" };

        public void Run()
        {
            var t = new Temperature();

            t.Celsius = 25;
            Console.WriteLine($"Цельсий: {t.Celsius}, Фаренгейт: {t.Fahrenheit}");

            try
            {
                t.Celsius = -300; // Ошибка
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }

    public class Temperature
    {
        private double _celsius;

        public double Celsius
        {
            get => _celsius;
            set
            {
                if (value < -273.15)
                    throw new ArgumentOutOfRangeException(nameof(value), "Температура не может быть ниже абсолютного нуля (-273.15°C)");
                _celsius = value;
            }
        }

        public double Fahrenheit => _celsius * 9 / 5 + 32;
    }
}