using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_sharp_practicum.Common;

namespace C_sharp_practicum.Tasks.Level1

{
    /// <summary>Задание 15 — Git: базовая работа с ветками и merge.</summary>
    public class Task15_GitBasics : ITask
    {
        /// <inheritdoc/>
        public string Title => "Git: репозиторий → ветка → merge → конфликт";

        /// <inheritdoc/>
        public string Description => "Пройти базовый git-сценарий: ветки, merge, разрешение конфликта.";

        /// <inheritdoc/>
        public string[] Requirements => new[]
        {
            "Репозиторий с 2–3 осмысленными коммитами",
            "Ветка feature/git-basics с изменением",
            "Merge в основную ветку",
            "Смоделировать и разрешить конфликт в README.md",
            "Вывод git log --graph сохранить в git-notes.md"
        };

        /// <inheritdoc/>
        public void Run()
        {
            Console.WriteLine("Это git-задание — код здесь не нужен.");
            Console.WriteLine("Сценарий и вывод команд смотрите в файле git-notes.md.");
            Console.WriteLine();
            Console.WriteLine("Кратко, что должно быть сделано:");
            Console.WriteLine("  1) 2–3 коммита в основной ветке");
            Console.WriteLine("  2) git checkout -b feature/git-basics");
            Console.WriteLine("  3) изменить README.md, закоммитить");
            Console.WriteLine("  4) git merge feature/git-basics");
            Console.WriteLine("  5) в двух ветках изменить одну строку README.md, merge,");
            Console.WriteLine("     убрать <<<<<<< маркеры вручную");
            Console.WriteLine("  6) git log --graph --oneline --all > в git-notes.md");
        }
    }
}