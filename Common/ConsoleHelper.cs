using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_practicum.Common

{
    /// <summary>Вспомогательные методы для консоли.</summary>
    public static class ConsoleHelper
    {
        /// <summary>Пауза до нажатия Enter.</summary>
        public static void Pause()
        {
            Console.WriteLine();
            Console.Write("Нажмите Enter для возврата в меню...");
            Console.ReadLine();
        }
    }
}