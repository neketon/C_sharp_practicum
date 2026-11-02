using C_sharp_practicum.Common;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace C_sharp_practicum.Tasks.Level3
{
    public class Task44_TodoList : ITask
    {
        public string Title => "Todo List (JSON)";
        public string Description => "Мини-проект списка задач с сохранением в файл.";
        public string[] Requirements => new[] { "CRUD", "System.Text.Json", "Обработка ошибок" };

        private string _filePath = "tasks.json";

        public void Run()
        {
            var service = new TaskService(_filePath);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- TODO LIST ---");
                Console.WriteLine("1. Показать все");
                Console.WriteLine("2. Добавить");
                Console.WriteLine("3. Отметить выполненной");
                Console.WriteLine("4. Удалить");
                Console.WriteLine("0. Выход");
                Console.Write("Выбор: ");

                string choice = Console.ReadLine();
                if (choice == "0") break;

                try
                {
                    switch (choice)
                    {
                        case "1": service.PrintAll(); break;
                        case "2":
                            Console.Write("Название задачи: ");
                            service.Add(Console.ReadLine());
                            break;
                        case "3":
                            Console.Write("ID задачи: ");
                            if (int.TryParse(Console.ReadLine(), out int idDone)) service.MarkDone(idDone);
                            else Console.WriteLine("Неверный ID");
                            break;
                        case "4":
                            Console.Write("ID задачи: ");
                            if (int.TryParse(Console.ReadLine(), out int idDel)) service.Delete(idDel);
                            else Console.WriteLine("Неверный ID");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                Console.WriteLine("\nНажмите Enter...");
                Console.ReadLine();
            }
        }
    }

    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
    }

    public class TaskService
    {
        private string _path;
        private List<TaskItem> _tasks;

        public TaskService(string path)
        {
            _path = path;
            Load();
        }

        private void Load()
        {
            if (File.Exists(_path))
            {
                string json = File.ReadAllText(_path);
                _tasks = JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
            }
            else
            {
                _tasks = new List<TaskItem>();
            }
        }

        private void Save()
        {
            string json = JsonSerializer.Serialize(_tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_path, json);
        }

        public void PrintAll()
        {
            if (_tasks.Count == 0) Console.WriteLine("Список пуст.");
            foreach (var t in _tasks)
                Console.WriteLine($"[{t.Id}] {(t.IsDone ? "[x]" : "[ ]")} {t.Title}");
        }

        public void Add(string title)
        {
            int id = _tasks.Count > 0 ? _tasks[_tasks.Count - 1].Id + 1 : 1;
            _tasks.Add(new TaskItem { Id = id, Title = title, IsDone = false });
            Save();
        }

        public void MarkDone(int id)
        {
            var task = _tasks.Find(t => t.Id == id);
            if (task != null) { task.IsDone = true; Save(); }
            else Console.WriteLine("Задача не найдена");
        }

        public void Delete(int id)
        {
            int removed = _tasks.RemoveAll(t => t.Id == id);
            if (removed > 0) Save();
            else Console.WriteLine("Задача не найдена");
        }
    }
}