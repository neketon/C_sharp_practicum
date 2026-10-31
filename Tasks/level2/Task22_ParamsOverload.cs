using C_sharp_practicum.Common;

using System;
using System.Collections.Generic;

namespace C_sharp_practicum.Tasks.Level2
{
    public class Task22_ParamsOverload : ITask
    {
        public string Title => "params-метод + перегрузка";
        public string Description => "Метод суммы с params и перегрузка для массива.";
        public string[] Requirements => new[] { "Sum(params int[])", "Sum(int[])" };

        public void Run()
        {
            Console.WriteLine($"Sum(1, 2, 3) = {Sum(1, 2, 3)}");
            Console.WriteLine($"Sum(new[] {{1, 2, 3}}) = {Sum(new int[] { 1, 2, 3 })}");
            Console.WriteLine($"Sum() = {Sum()}");
        }

        private int Sum(params int[] numbers)
        {
            int sum = 0;
            foreach (int n in numbers) sum += n;
            return sum;
        }

        private int Sum(int[] numbers)
        {
            return Sum((IEnumerable<int>)numbers); // вызов params-версии
        }
    }
}