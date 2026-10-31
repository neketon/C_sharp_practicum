using C_sharp_practicum.Common;

using System;
using System.Collections.Generic;

namespace C_sharp_practicum.Tasks.Level2
{
    public class Task24_Animals : ITask
    {
        public string Title => "ООП: Animal → Dog/Cat/Bird";
        public string Description => "Иерархия животных с полиморфизмом.";
        public string[] Requirements => new[] { "Абстрактный класс", "Полиморфизм" };

        public void Run()
        {
            List<Animal> animals = new List<Animal>
            {
                new Dog { Name = "Бобик" },
                new Cat { Name = "Мурка" },
                new Bird { Name = "Кеша" }
            };

            foreach (var animal in animals)
            {
                Console.WriteLine($"{animal} говорит: {animal.MakeSound()}");
                if (animal is Bird bird) bird.Fly();
            }
        }
    }

    public abstract class Animal
    {
        public string Name { get; set; }
        public abstract string MakeSound();
        public override string ToString() => $"Животное: {Name}";
    }

    public class Dog : Animal
    {
        public override string MakeSound() => "Гав-гав!";
    }

    public class Cat : Animal
    {
        public override string MakeSound() => "Мяу!";
    }

    public class Bird : Animal
    {
        public override string MakeSound() => "Чирик!";
        public void Fly() => Console.WriteLine($"{Name} летит!");
    }
}