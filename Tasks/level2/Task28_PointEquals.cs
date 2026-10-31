using C_sharp_practicum.Common;

using System;
using System.Collections.Generic;

namespace C_sharp_practicum.Tasks.Level2
{
    public class Task28_PointEquals : ITask
    {
        public string Title => "Equals / GetHashCode для Point";
        public string Description => "Переопределение равенства и хэш-кода.";
        public string[] Requirements => new[] { "IEquatable<Point>", "HashSet<Point>" };

        public void Run()
        {
            var p1 = new Point(1, 2);
            var p2 = new Point(1, 2);
            var p3 = new Point(3, 4);

            Console.WriteLine($"p1.Equals(p2): {p1.Equals(p2)}");
            Console.WriteLine($"p1.Equals(p3): {p1.Equals(p3)}");
            Console.WriteLine($"p1 == p2: {p1 == p2}"); // Если переопределен оператор ==

            var set = new HashSet<Point> { p1, p2, p3 };
            Console.WriteLine($"Количество уникальных точек в HashSet: {set.Count}");
        }
    }

    public class Point : IEquatable<Point>
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y) { X = x; Y = y; }

        public bool Equals(Point other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj) => Equals(obj as Point);

        public override int GetHashCode()
        {
            // Старый надежный способ вычисления хэш-кода:
            // берем X, умножаем на простое число и прибавляем Y.
            unchecked // отключает проверку на переполнение (чтобы не было ошибок)
            {
                int hash = 17;
                hash = hash * 23 + X.GetHashCode();
                hash = hash * 23 + Y.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(Point left, Point right) => Equals(left, right);
        public static bool operator !=(Point left, Point right) => !Equals(left, right);
    }
}