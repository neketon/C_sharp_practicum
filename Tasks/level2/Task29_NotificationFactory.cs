using C_sharp_practicum.Common;

using System;

namespace C_sharp_practicum.Tasks.Level2
{
    public class Task29_NotificationFactory : ITask
    {
        public string Title => "Паттерн «Фабрика» (уведомления)";
        public string Description => "Создание уведомлений через фабрику.";
        public string[] Requirements => new[] { "INotification", "NotificationFactory" };

        public void Run()
        {
            var email = NotificationFactory.Create(NotificationType.Email);
            email.Send("Привет по почте!");

            var sms = NotificationFactory.Create(NotificationType.Sms);
            sms.Send("SMS-сообщение!");

            var push = NotificationFactory.Create(NotificationType.Push);
            push.Send("Push-уведомление!");
        }
    }

    public enum NotificationType { Email, Sms, Push }

    public interface INotification
    {
        void Send(string message);
    }

    public class EmailNotification : INotification
    {
        public void Send(string message) => Console.WriteLine($"[Email] {message}");
    }

    public class SmsNotification : INotification
    {
        public void Send(string message) => Console.WriteLine($"[SMS] {message}");
    }

    public class PushNotification : INotification
    {
        public void Send(string message) => Console.WriteLine($"[Push] {message}");
    }

    public static class NotificationFactory
    {
        public static INotification Create(NotificationType type)
        {
            switch (type)
            {
                case NotificationType.Email: return new EmailNotification();
                case NotificationType.Sms: return new SmsNotification();
                case NotificationType.Push: return new PushNotification();
                default: throw new ArgumentException("Неизвестный тип уведомления");
            }
        }
    }
}