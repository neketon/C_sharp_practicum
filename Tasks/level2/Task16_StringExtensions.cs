using C_sharp_practicum.Common;
using System.Collections.Generic;
using System;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_practicum.Tasks.Level2
{
    public class Task16_StringExtensions : ITask
    {
        public string Title => "Методы расширения для string";
        public string Description => "Написать extension-методы для string: IsPalindrome, WordCount, ReverseString.";
        public string[] Requirements => new[] { "Класс StringExtensions", "Вызов как \"abc\".ReverseString()" };

        public void Run()
        {
            string test1 = "А роза упала на лапу Азора";
            string test2 = "Hello world, this is C#!";

            Console.WriteLine($"Строка: \"{test1}\"");
            Console.WriteLine($"Палиндром: {test1.IsPalindrome()}");
            Console.WriteLine($"Слов: {test1.WordCount()}");
            Console.WriteLine($"Реверс: \"{test1.ReverseString()}\"");
            Console.WriteLine();
            Console.WriteLine($"Строка: \"{test2}\"");
            Console.WriteLine($"Палиндром: {test2.IsPalindrome()}");
            Console.WriteLine($"Слов: {test2.WordCount()}");
            Console.WriteLine($"Реверс: \"{test2.ReverseString()}\"");
        }
    }

    public static class StringExtensions
    {
        public static bool IsPalindrome(this string str)
        {
            if (string.IsNullOrEmpty(str)) return true;
            string clean = "";
            foreach (char c in str.ToLower())
                if (char.IsLetterOrDigit(c)) clean += c;

            for (int i = 0; i < clean.Length / 2; i++)
                if (clean[i] != clean[clean.Length - 1 - i]) return false;
            return true;
        }

        public static int WordCount(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return 0;
            return str.Split(new[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static string ReverseString(this string str)
        {
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}