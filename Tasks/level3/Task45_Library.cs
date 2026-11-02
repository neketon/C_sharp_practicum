using C_sharp_practicum.Common;

using System;
using System.Collections.Generic;

namespace C_sharp_practicum.Tasks.Level3
{
    public class Task45_Library : ITask
    {
        public string Title => "Библиотека + юнит-тесты";
        public string Description => "Логика выдачи книг (тесты создаются отдельно).";
        public string[] Requirements => new[] { "Классы Book, Reader, Library", "Лимит 3 книги" };

        public void Run()
        {
            Console.WriteLine("Классы библиотеки созданы. Тесты нужно запустить в отдельном проекте (см. инструкцию).");
            // Демонстрация работы
            var lib = new Library();
            var book = new Book("Война и мир", "Толстой");
            var reader = new Reader("Иван");

            lib.BorrowBook(book, reader);
            Console.WriteLine($"Иван взял книгу: {book.Title}. Доступна: {book.IsAvailable}");
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsAvailable { get; set; } = true;
        public Book(string title, string author) { Title = title; Author = author; }
    }

    public class Reader
    {
        public string Name { get; set; }
        public List<Book> BorrowedBooks { get; set; } = new List<Book>();
        public Reader(string name) { Name = name; }
    }

    public class Library
    {
        public void BorrowBook(Book book, Reader reader)
        {
            if (!book.IsAvailable) throw new InvalidOperationException("Книга уже выдана.");
            if (reader.BorrowedBooks.Count >= 3) throw new InvalidOperationException("Превышен лимит (3 книги).");

            book.IsAvailable = false;
            reader.BorrowedBooks.Add(book);
        }

        public void ReturnBook(Book book, Reader reader)
        {
            if (reader.BorrowedBooks.Remove(book))
                book.IsAvailable = true;
        }
    }
}