using C_sharp_practicum.Common;

using System;

namespace C_sharp_practicum.Tasks.Level2
{
    public class Task30_BankAccount : ITask
    {
        public string Title => "BankAccount + свой Exception";
        public string Description => "Банковский счет с кастомным исключением.";
        public string[] Requirements => new[] { "InsufficientFundsException", "try/catch" };

        public void Run()
        {
            var account = new BankAccount();

            try
            {
                account.Deposit(1000);
                Console.WriteLine("Пополнение на 1000. Баланс: " + account.Balance);
                account.Withdraw(500);
                Console.WriteLine("Снятие 500. Баланс: " + account.Balance);

                account.Withdraw(1000); // Вызовет исключение
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine($"Текущий баланс: {account.Balance}");
            }
        }
    }

    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message) : base(message) { }
    }

    public class BankAccount
    {
        public decimal Balance { get; private set; }

        public void Deposit(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Сумма должна быть положительной");
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Сумма должна быть положительной");
            if (amount > Balance)
                throw new InsufficientFundsException($"Недостаточно средств для снятия {amount}. На балансе: {Balance}");

            Balance -= amount;
        }
    }
}