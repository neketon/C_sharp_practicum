using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_sharp_practicum.Common;


    /// <summary>Задание 3 — калькулятор с обработкой деления на ноль.</summary>
    public class Task03_Calculator : ITask
{
    /// <inheritdoc/>
    public string Title => "Калькулятор с делением на ноль";

    /// <inheritdoc/>
    public string Description => "Принимает два числа и оператор, выводит результат. Обработать деление на ноль.";

    /// <inheritdoc/>
    public string[] Requirements => new[]
    {
            "Оператор через switch",
            "Деление на ноль — сообщение, приложение не падает",
            "Некорректный оператор — «Неизвестная операция»",
            "Числа через TryParse"
        };

    /// <inheritdoc/>
    public void Run()
    {
        Console.Write("Первое число: ");
        string s1 = Console.ReadLine();
        Console.Write("Оператор (+, -, *, /): ");
        string op = Console.ReadLine();
        Console.Write("Второе число: ");
        string s2 = Console.ReadLine();

        if (!double.TryParse(s1, out double a))
        {
            Console.WriteLine("Первое число введено неверно");
            return;
        }
        if (!double.TryParse(s2, out double b))
        {
            Console.WriteLine("Второе число введено неверно");
            return;
        }

        switch (op)
        {
            case "+":
                Console.WriteLine($"{a} + {b} = {a + b}");
                break;
            case "-":
                Console.WriteLine($"{a} - {b} = {a - b}");
                break;
            case "*":
                Console.WriteLine($"{a} * {b} = {a * b}");
                break;
            case "/":
                if (b == 0)
                    Console.WriteLine("Ошибка: деление на ноль!");
                else
                    Console.WriteLine($"{a} / {b} = {a / b}");
                break;
            default:
                Console.WriteLine("Неизвестная операция");
                break;
        }
    }
}
