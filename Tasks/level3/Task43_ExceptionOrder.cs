using C_sharp_practicum.Common;
using System;

namespace C_sharp_practicum.Tasks.Level3
{
    public class Task43_ExceptionOrder : ITask
    {
        public string Title => "Множественные исключения";
        public string Description => "Порядок catch-блоков и finally.";
        public string[] Requirements => new[] { "FormatException", "DivideByZeroException", "finally" };

        public void Run()
        {
            TestException("abc");
            TestException(0);
            TestException(-1);
        }

        private void TestException(object input)
        {
            try
            {
                if (input is string s)
                    int.Parse(s); // Вызовет FormatException

                if (input is int i)
                {
                    if (i == -1) throw new CustomException("Кастомная ошибка!");
                    int result = 10 / i; // Вызовет DivideByZeroException при i=0
                }
            }
            // Важно: от частного к общему. FormatException и DivideByZeroException - частные случаи.
            catch (FormatException)
            {
                Console.WriteLine("Поймано: FormatException (неверный формат)");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Поймано: DivideByZeroException (деление на ноль)");
            }
            catch (CustomException ex)
            {
                Console.WriteLine($"Поймано: {ex.Message}");
            }
            catch (Exception ex) // Общий случай (должен быть последним!)
            {
                Console.WriteLine($"Поймано неизвестное исключение: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Блок finally: завершено.\n");
            }
        }
    }

    public class CustomException : Exception
    {
        public CustomException(string message) : base(message) { }
    }
}