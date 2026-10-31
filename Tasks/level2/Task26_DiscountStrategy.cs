using C_sharp_practicum.Common;

using System;

namespace C_sharp_practicum.Tasks.Level2
{
    public class Task26_DiscountStrategy : ITask
    {
        public string Title => "Паттерн «Стратегия» (скидки)";
        public string Description => "Калькулятор скидок через паттерн Стратегия.";
        public string[] Requirements => new[] { "IDiscountStrategy", "PriceCalculator" };

        public void Run()
        {
            decimal price = 1000m;

            var calculator = new PriceCalculator(new NoDiscount());
            Console.WriteLine($"Без скидки: {calculator.Calculate(price)}");

            calculator.SetStrategy(new VipDiscount());
            Console.WriteLine($"VIP (10%): {calculator.Calculate(price)}");

            calculator.SetStrategy(new PromoDiscount());
            Console.WriteLine($"Промо (20%): {calculator.Calculate(price)}");
        }
    }

    public interface IDiscountStrategy
    {
        decimal Apply(decimal price);
    }

    public class NoDiscount : IDiscountStrategy
    {
        public decimal Apply(decimal price) => price;
    }

    public class VipDiscount : IDiscountStrategy
    {
        public decimal Apply(decimal price) => price * 0.9m;
    }

    public class PromoDiscount : IDiscountStrategy
    {
        public decimal Apply(decimal price) => price * 0.8m;
    }

    public class PriceCalculator
    {
        private IDiscountStrategy _strategy;
        public PriceCalculator(IDiscountStrategy strategy) => _strategy = strategy;
        public void SetStrategy(IDiscountStrategy strategy) => _strategy = strategy;
        public decimal Calculate(decimal price) => _strategy.Apply(price);
    }
}