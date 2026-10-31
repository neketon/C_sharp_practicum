using C_sharp_practicum.Common;

using System;
using System.Collections.Generic;
using System.Linq;

namespace C_sharp_practicum.Tasks.Level2
{
    public class Task25_Shapes : ITask
    {
        public string Title => "Интерфейс IShape + сортировка фигур";
        public string Description => "Сортировка фигур по площади.";
        public string[] Requirements => new[] { "Интерфейс IShape", "List<IShape>", "Сортировка" };

        public void Run()
        {
            List<IShape> shapes = new List<IShape>
            {
                new Circle(5),
                new Rectangle(2, 4),
                new Triangle(3, 4, 5),
                new Rectangle(10, 1),
                new Circle(1)
            };

            Console.WriteLine("До сортировки:");
            foreach (var s in shapes) Console.WriteLine($"{s.GetType().Name}: площадь {s.Area():F2}");

            shapes.Sort((s1, s2) => s1.Area().CompareTo(s2.Area())); // Сортировка по площади

            Console.WriteLine("\nПосле сортировки:");
            foreach (var s in shapes) Console.WriteLine($"{s.GetType().Name}: площадь {s.Area():F2}");
        }
    }

    public interface IShape
    {
        double Area();
        double Perimeter();
    }

    public class Circle : IShape
    {
        public double Radius { get; }
        public Circle(double radius) => Radius = radius;
        public double Area() => Math.PI * Radius * Radius;
        public double Perimeter() => 2 * Math.PI * Radius;
    }

    public class Rectangle : IShape
    {
        public double Width { get; }
        public double Height { get; }
        public Rectangle(double width, double height) { Width = width; Height = height; }
        public double Area() => Width * Height;
        public double Perimeter() => 2 * (Width + Height);
    }

    public class Triangle : IShape
    {
        public double A { get; }
        public double B { get; }
        public double C { get; }
        public Triangle(double a, double b, double c) { A = a; B = b; C = c; }
        public double Area()
        {
            double p = (A + B + C) / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }
        public double Perimeter() => A + B + C;
    }
}