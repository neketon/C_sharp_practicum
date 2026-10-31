using C_sharp_practicum.Common;

using System;

namespace C_sharp_practicum.Tasks.Level2
{
    public class Task20_Generics : ITask
    {
        public string Title => "Обобщения: Swap<T>, Max<T>";
        public string Description => "Обобщенные методы с ограничениями и без.";
        public string[] Requirements => new[] { "Swap(ref a, ref b)", "Max with IComparable<T>" };

        public void Run()
        {
            int a = 5, b = 10;
            Console.WriteLine($"До Swap: a={a}, b={b}");
            Swap(ref a, ref b);
            Console.WriteLine($"После Swap: a={a}, b={b}");
            Console.WriteLine($"Max(5, 10) = {Max(5, 10)}");

            string s1 = "apple", s2 = "banana";
            Console.WriteLine($"До Swap: s1={s1}, s2={s2}");
            Swap(ref s1, ref s2);
            Console.WriteLine($"После Swap: s1={s1}, s2={s2}");
            Console.WriteLine($"Max(\"apple\", \"banana\") = {Max("apple", "banana")}");

            double d1 = 3.14, d2 = 2.71;
            Swap(ref d1, ref d2);
            Console.WriteLine($"Swap double: d1={d1}, d2={d2}, Max = {Max(d1, d2)}");
        }

        private void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        private T Max<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) > 0 ? a : b;
        }
    }
}