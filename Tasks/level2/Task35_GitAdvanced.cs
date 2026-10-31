using C_sharp_practicum.Common;

using System;

namespace C_sharp_practicum.Tasks.Level2
{
    public class Task35_GitAdvanced : ITask
    {
        public string Title => "Git: .gitignore, PR, rebase";
        public string Description => "Продвинутый git-сценарий (ветки, rebase, squash).";
        public string[] Requirements => new[] { "Создать .editorconfig", "Ветка feature/task-35", "git rebase -i HEAD~3" };

        public void Run()
        {
            Console.WriteLine("Это задание на Git. Кода в C# здесь нет.");
            Console.WriteLine("Все выполненные команды и вывод git log сохранены в файле git-notes.md.");
            Console.WriteLine();
            Console.WriteLine("Что нужно было сделать:");
            Console.WriteLine("1. Добавить .editorconfig.");
            Console.WriteLine("2. Создать ветку feature/task-35, сделать пару коммитов.");
            Console.WriteLine("3. Запушить и сделать Pull Request.");
            Console.WriteLine("4. Объединить коммиты через rebase.");
        }
    }
}