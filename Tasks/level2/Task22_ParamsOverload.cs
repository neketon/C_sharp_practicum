using C_sharp_practicum.Common;

using System;

namespace C_sharp_practicum.Tasks.Level2
{
    public class Task22_ParamsOverload : ITask
    {
        public string Title => "params-метод + перегрузка";
        public string Description => "Метод суммы с params и перегрузка.";
        public string[] Requirements => new[] { "Sum(params int[])", "Перегрузка для массива" };

        public void Run()
        {
            // Вызов params-версии
            Console.WriteLine($"Sum(1, 2, 3) = {Sum(1, 2, 3)}");

            // Вызов перегрузки для массива
            int[] arr = { 1, 2, 3 };
            Console.WriteLine($"Sum(new[] {{1, 2, 3}}) = {Sum(arr)}");

            // Пустой вызов
            Console.WriteLine($"Sum() = {Sum()}");

            // Перегрузка, принимающая коллекцию (чтобы избежать конфликта с int[])
            var list = new System.Collections.Generic.List<int> { 10, 20 };
            Console.WriteLine($"Sum(List<int>) = {Sum(list)}");
        }

        // 1. Версия с params
        private int Sum(params int[] numbers)
        {
            int sum = 0;
            foreach (int n in numbers) sum += n;
            return sum;
        }

        // 2. Перегрузка, принимающая IEnumerable<int> (это законно)
        private int Sum(System.Collections.Generic.IEnumerable<int> numbers)
        {
            int sum = 0;
            foreach (int n in numbers) sum += n;
            return sum;
        }
    }
}