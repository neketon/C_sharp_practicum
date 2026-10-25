using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_practicum.Common
{
    /// <summary>Контракт задания практикума.</summary>
    public interface ITask
    {
        /// <summary>Название задания для меню.</summary>
        string Title { get; }

        /// <summary>Описание задания.</summary>
        string Description { get; }

        /// <summary>Требования к заданию.</summary>
        string[] Requirements { get; }

        /// <summary>Запуск решения.</summary>
        void Run();
    }
}