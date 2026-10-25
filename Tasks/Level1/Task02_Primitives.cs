using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_sharp_practicum.Common;

namespace C_sharp_practicum.Tasks.Level1
{
    /// <summary>Задание 2 — переменные примитивных типов.</summary>
    public class Task02_Primitives : ITask
    {
        /// <inheritdoc/>
        public string Title => "Переменные примитивных типов";

        /// <inheritdoc/>
        public string Description => "Объявить переменные всех примитивных типов и вывести значения и типы.";

        /// <inheritdoc/>
        public string[] Requirements => new[]
        {
            "Минимум: int, long, double, float, decimal, bool, char, string",
            "Вывести значение и GetType().Name",
            "decimal с суффиксом m, float с суффиксом f"
        };

        /// <inheritdoc/>
        public void Run()
        {
            int i = 42;
            long l = 1234567890123L;
            double d = 3.14159;
            float f = 2.5f;
            decimal m = 199.99m;
            bool b = true;
            char c = 'A';
            string s = "Привет";

            Print("int", i);
            Print("long", l);
            Print("double", d);
            Print("float", f);
            Print("decimal", m);
            Print("bool", b);
            Print("char", c);
            Print("string", s);
        }

        private void Print(string name, object value)
        {
            Console.WriteLine($"{name} = {value} ({value.GetType().Name})");
        }
    }
}